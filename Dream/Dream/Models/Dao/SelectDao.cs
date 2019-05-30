using Dream.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dream.Models.Dao
{
    public class SelectDao : System.Web.UI.Page
    {
        private readonly SqlConnection con;
        /// <summary>トランザクション</summary>
        private readonly SqlTransaction trn;
        public SelectDao()
        {
            con = TranMng.Transaction.Connection;
            trn = TranMng.Transaction;
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

    }
}