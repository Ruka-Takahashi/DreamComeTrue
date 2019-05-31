using Dream.Models;
using Dream.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class NewLoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error.Text = "";
        }

        protected void CreateUser_Button_Click(object sender, EventArgs e)
        {
            string id = ID_TextBox.Text;
            string pw = PW_TextBox.Text;
            string pw_cheak = PW_Check.Text;

            if (id != ""&&pw !="")
            {
                if(pw == pw_cheak)
                {
                    using (TranMng TM = new TranMng())
                    {
                        UserDao ID = new UserDao();
                        string msg = ID.Insert(ID_TextBox.Text, PW_TextBox.Text);
                        Session.Add("msg", msg);
                        Server.Transfer("Result.aspx");
                    }
                }
                else
                {
                    Error.Text = "パスワードが一致しません。";

                }
            }
            else
            {
                Error.Text = "未入力の内容があります。";
            }
        }

        //protected void Button1_Click(object sender, EventArgs e) {
        //    Server.Transfer("Menu.aspx");
        //}

        protected void Button1_Click1(object sender, EventArgs e) {
            Server.Transfer("Menu.aspx");
        }
    }
}