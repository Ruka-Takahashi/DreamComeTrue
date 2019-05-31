using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class SearchEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Search2.DataBind();

        }
    }
}