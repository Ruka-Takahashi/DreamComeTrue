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

        }

        protected void CreateUser_Button_Click(object sender, EventArgs e)
        {
            using (TranMng TM = new TranMng())
            {
                InsertDao ID = new InsertDao();
                string msg = ID.Insert_LoginUser(ID_TextBox.Text, PW_TextBox.Text);
                Session.Add("msg", msg);
                Server.Transfer("Result.aspx");
            }
        }
    }
}