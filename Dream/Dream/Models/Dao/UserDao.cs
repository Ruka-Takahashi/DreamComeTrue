using Dream.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class UserDao : System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public UserDao()
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
        public string Insert(string user_id, string password)
        {
            string message = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO m_user VALUES(@user_id,@password,@date,@date)", con, trn))
                {
                    cmd.Parameters.Add(new SqlParameter("@user_id", SqlDbType.VarChar)).Value = user_id;
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = password;

                    DateTime dt = DateTime.Now;
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = dt;

                    //ここで更新
                    cmd.ExecuteNonQuery();
                    //ここで確定
                    trn.Commit();

                    message = user_id + "さんを登録しました。";
                }
            }
            catch (FormatException)
            {
                message = "入力形式が正しくありません。";
            }
            catch (SqlException)
            {
                message = "登録できませんでした。";
            }
            return message;
        }

    }
}