using Dream.Models;
using Dream.Models.Dao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dream
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (TranMng TM = new TranMng())
                {
                    SelectDao SD = new SelectDao();
                    int count = SD.Select();
                    if (count == 0)
                    {
                        Emp_Cd_List.Visible = false;
                        DeleteButton.Visible = false;

                    }
                }
            }

            DeleteButton.Attributes["OnClick"] = "return confirm('本当に削除しますか？');";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Menu.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            using (TranMng TM = new TranMng())
            {
                DeleteDao DD = new DeleteDao();
                string error = DD.Delete(Emp_Cd_List.Text);
                Session.Add("msg", error);
                Server.Transfer("Result.aspx");
            }
        }

        protected void UpDateButton_Click(object sender, EventArgs e)
        {
            Session.Add("UserId", Emp_Cd_List.Text);
            Server.Transfer("UpDateUser.aspx");
        }
    }
}