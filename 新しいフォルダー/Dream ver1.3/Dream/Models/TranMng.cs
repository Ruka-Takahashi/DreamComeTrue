using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Dream.Models
{
    class TranMng : IDisposable
    {
        /// <summary>排他制御</summary>
        private static ReaderWriterLock @lock = new ReaderWriterLock();

        /// <summary>コンテキスト</summary>
        private static Dictionary<int, KeyValuePair<SqlConnection, SqlTransaction>> context;

        /// <summary>トランザクション</summary>
        public static SqlTransaction Transaction
        {
            get
            {
                int id = Thread.CurrentThread.ManagedThreadId;
                try
                {
                    @lock.AcquireReaderLock(Timeout.Infinite);
                    return context[id].Value;
                }
                finally
                {
                    @lock.ReleaseReaderLock();
                }
            }
        }

        /// <summary>コネクションマネージャ</summary>
        public TranMng()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            try
            {
                @lock.AcquireWriterLock(Timeout.Infinite);
                if (context == null)
                    context = new Dictionary<int, KeyValuePair<SqlConnection, SqlTransaction>>();
                if (!context.ContainsKey(id))
                {
                    SqlConnection con = new SqlConnection(new SqlConnectionStringBuilder
                    {
                        DataSource = "LocalHost",
                        UserID = "DreamU",
                        Password = "DreamP",
                        InitialCatalog = "Dream_db"
                    }.ToString());
                    con.Open();
                    context.Add(id, new KeyValuePair<SqlConnection, SqlTransaction>(con, con.BeginTransaction()));
                }
            }
            finally
            {
                @lock.ReleaseWriterLock();
            }
        }

        /// <summary>リソースの開放</summary>
        public void Dispose()
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            try
            {
                @lock.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    context[id].Value.Dispose();
                    context[id].Key.Close();
                    context[id].Key.Dispose();
                }
                finally
                {
                    context.Remove(id);
                }
            }
            finally
            {
                @lock.ReleaseWriterLock();
            }
        }
    }
}
