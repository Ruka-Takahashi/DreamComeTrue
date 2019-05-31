using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class InsertDao : System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public InsertDao()
        {
            con = TranMng.Transaction.Connection;
            trn = TranMng.Transaction;
        }
        public string Insert(string emp_cd, string last_nm, string first_nm, string last_nm_kana, string first_nm_kana, int gender_cd, string birth_date, string section_cd, string emp_date)
        {
            string error = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO m_employee VALUES(@emp_cd,@last_nm,@first_nm,@last_nm_kana,@first_nm_kana,@gender_cd,@birth_date,@section_cd,@emp_date,@date,@date)", con, trn))
                {
                    cmd.Parameters.Add(new SqlParameter("@emp_cd", SqlDbType.Char)).Value = emp_cd;
                    cmd.Parameters.Add(new SqlParameter("@last_nm", SqlDbType.NVarChar)).Value = last_nm;
                    cmd.Parameters.Add(new SqlParameter("@first_nm", SqlDbType.NVarChar)).Value = first_nm;
                    cmd.Parameters.Add(new SqlParameter("@last_nm_kana", SqlDbType.NVarChar)).Value = last_nm_kana;
                    cmd.Parameters.Add(new SqlParameter("@first_nm_kana", SqlDbType.NVarChar)).Value = first_nm_kana;
                    cmd.Parameters.Add(new SqlParameter("@gender_cd", SqlDbType.TinyInt)).Value = gender_cd;
                    cmd.Parameters.Add(new SqlParameter("@birth_date", SqlDbType.Date)).Value = birth_date;
                    cmd.Parameters.Add(new SqlParameter("@section_cd", SqlDbType.Char)).Value = section_cd;
                    cmd.Parameters.Add(new SqlParameter("@emp_date", SqlDbType.Date)).Value = emp_date;

                    DateTime dt = DateTime.Now;
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = dt;

                    //ここで更新
                    cmd.ExecuteNonQuery();
                    //ここで確定
                    trn.Commit();

                    error = last_nm + first_nm + "さんを登録しました。";
                }
            }
            catch (FormatException)
            {
                error = "入力形式が正しくありません。";
            }
            catch (SqlException)
            {
                error = "登録できませんでした。";
            }
            return error;
        }
        public string Insert_LoginUser(string user_id, string password)
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