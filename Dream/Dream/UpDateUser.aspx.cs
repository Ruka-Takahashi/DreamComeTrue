using Dream.Models;
using Dream.Models.Dao;
using Dream.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class UpDateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //ユーザー一覧で選択した従業員の情報を最初から表示したい
                EUser EU = new EUser();
                using (TranMng TM = new TranMng())
                {

                    string UserId = Session["UserId"].ToString();
                    user.Text = UserId;
                    //選んだユーザーの情報をエンティティに保存
                    EmployeeDao SD = new EmployeeDao();
                    EU = SD.Select(UserId);
                    last_nm.Text = EU.last_nm;
                    first_nm.Text = EU.first_nm;
                    last_nm_kana.Text = EU.last_nm_kana;
                    first_nm_kana.Text = EU.first_nm_kana;
                }

                DropDownList1.SelectedIndex = EU.gender_cd;

                ListItem li2 = DropDownList2.Items.FindByValue(EU.section_cd);
                int section_idx = DropDownList2.Items.IndexOf(li2);
                DropDownList2.SelectedIndex = section_idx;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            using (TranMng TM = new TranMng())
            {
                EmployeeDao UD = new EmployeeDao();
                string msg = UD.UpDate(user.Text, last_nm.Text, first_nm.Text, last_nm_kana.Text, first_nm_kana.Text, int.Parse(DropDownList1.Text), DropDownList2.Text);
                Session.Add("msg", msg);
                Server.Transfer("Result.aspx");
            }
        }
    }
}