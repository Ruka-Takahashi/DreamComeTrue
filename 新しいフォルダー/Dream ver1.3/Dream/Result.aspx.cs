using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Label1.Text = Session["msg"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("msg");
            Server.Transfer("Menu.aspx");
        }
    }
}