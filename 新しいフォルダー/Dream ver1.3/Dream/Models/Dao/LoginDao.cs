using Dream.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{ 
    public class LoginDao : System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public LoginDao()
        {
            con = TranMng.Transaction.Connection;
            trn = TranMng.Transaction;
        }
        public DUser Login(string userId)
        {

            DUser duser = null;
            using (SqlCommand cmd = new SqlCommand("Select * FROM m_user WHERE user_id = @ID", con, trn))
            {
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar)).Value = userId;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        duser = new DUser();
                        duser.UserId = reader["user_id"].ToString();
                        duser.Password = reader["password"].ToString();
                    }
                    reader.Close();
                }
            }
            return duser;
        }
    }
}