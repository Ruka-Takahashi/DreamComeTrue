using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class UpDateDao : System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public UpDateDao()
        {
            con = TranMng.Transaction.Connection;
            trn = TranMng.Transaction;
        }

        public string UpDate(string emp_cd, string last_nm, string first_nm, string last_nm_kana, string first_nm_kana, int gender_cd, string section_cd)
        {
            string error = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE m_employee SET last_nm = @last_nm,first_nm = @first_nm,last_nm_kana = @last_nm_kana,first_nm_kana = @first_nm_kana,gender_cd = @gender_cd,section_cd = @section_cd,updated = @date WHERE emp_cd = @emp_cd", con, trn))
                {
                    cmd.Parameters.Add(new SqlParameter("@emp_cd", SqlDbType.Char)).Value = emp_cd;
                    cmd.Parameters.Add(new SqlParameter("@last_nm", SqlDbType.NVarChar)).Value = last_nm;
                    cmd.Parameters.Add(new SqlParameter("@first_nm", SqlDbType.NVarChar)).Value = first_nm;
                    cmd.Parameters.Add(new SqlParameter("@last_nm_kana", SqlDbType.NVarChar)).Value = last_nm_kana;
                    cmd.Parameters.Add(new SqlParameter("@first_nm_kana", SqlDbType.NVarChar)).Value = first_nm_kana;
                    cmd.Parameters.Add(new SqlParameter("@gender_cd", SqlDbType.TinyInt)).Value = gender_cd;
                    cmd.Parameters.Add(new SqlParameter("@section_cd", SqlDbType.Char)).Value = section_cd;

                    DateTime dt = DateTime.Now;
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = dt;

                    //ここで更新
                    cmd.ExecuteNonQuery();
                    //ここで確定
                    trn.Commit();

                    error = last_nm + first_nm + "さんを更新しました。";
                }

            }
            catch (SqlException)
            {
                error = "更新できませんでした。";
            }
            return error;
        }
    }
}