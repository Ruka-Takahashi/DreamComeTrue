using Dream.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class EmployeeDao: System.Web.UI.Page
    {
        /// <summary>コネクション</summary>
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public EmployeeDao()
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
        public int Select()
        {
            int count = 0;
            using (SqlCommand cmd = new SqlCommand("Select * FROM m_employee", con, trn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        count++;
                    }
                    reader.Close();
                }
            }
            return count;
        }
        public EUser Select(string emp_cd)
        {
            EUser EU = null;
            using (SqlCommand cmd = new SqlCommand("Select * FROM m_employee WHERE emp_cd = @emp_cd", con, trn))
            {
                cmd.Parameters.Add(new SqlParameter("@emp_cd", SqlDbType.Char)).Value = emp_cd;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        EU = new EUser();
                        EU.emp_cd = emp_cd;
                        EU.last_nm = reader["last_nm"].ToString();
                        EU.first_nm = reader["first_nm"].ToString();
                        EU.last_nm_kana = reader["last_nm_kana"].ToString();
                        EU.first_nm_kana = reader["first_nm_kana"].ToString();
                        EU.gender_cd = int.Parse(reader["gender_cd"].ToString());
                        EU.section_cd = reader["section_cd"].ToString();
                        reader.Close();
                    }
                }
            }
            return EU;
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
                    if (i == 1)
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