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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (TranMng TM = new TranMng())
            {
                UserDao LD = new UserDao();
                string id = TextBox1.Text;

                DUser duser = LD.Login(id);

                if (duser != null)
                {
                    if (duser.Password == TextBox2.Text)
                    {
                        Session["id"] = duser.UserId;
                        Server.Transfer("Menu.aspx");
                    }
                    else
                    {
                        Server.Transfer("LoginError.html");
                    }
                }
                else
                {
                    Server.Transfer("LoginError.html");
                }
            }
        }
    }
}
