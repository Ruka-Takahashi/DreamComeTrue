using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class DeleteDao : System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public DeleteDao()
        {
            con = TranMng.Transaction.Connection;
            trn = TranMng.Transaction;
        }

        public string Delete(string id)
        {
            string error = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM m_employee WHERE emp_cd = @id", con, trn))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Char)).Value = id;
                    //ここで更新
                    int i = cmd.ExecuteNonQuery();
                    if(i == 1)
                        error = "削除しました。";
                    else
                        error = "削除できませんでした。";

                    //ここで確定
                    trn.Commit();
                }
            }
            catch (SqlException e)
            {
                error = "削除できませんでした。";
            }
            return error;
        }
    }
}
