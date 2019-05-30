using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["id"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("UserList.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewUser.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //セッションを削除
            Session.Remove("id");
            //ログアウト画面に遷移
            Server.Transfer("logout.html");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewLoginUser.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("SearchEmployee.aspx");
        }
    }
}