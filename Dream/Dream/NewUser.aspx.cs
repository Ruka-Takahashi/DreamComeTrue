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
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int days = 31;
            //初めにページを開いたときのみ年月のリストを生成します（日にちも３１日までで作ります）
            if (!IsPostBack)
            {
                for (int i = 1940; i <= 2020; i++)
                {
                    BirthYearList.Items.Add(i.ToString());
                    JoinYearList.Items.Add(i.ToString());

                }
                for (int i = 1; i <= 12; i++)
                {
                    BirthMonthList.Items.Add(i.ToString());
                    JoinMonthList.Items.Add(i.ToString());

                }
                for (int i = 1; i <= days; i++)
                {
                    BirthDayList.Items.Add(i.ToString());
                    JoinDayList.Items.Add(i.ToString());

                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (TranMng TM = new TranMng())
            {
                //現在保存しているセッションを削除
                InsertDao ID = new InsertDao();
                Session.Remove("msg");
                string error = "";
                try
                {
                    //入力された情報をインサート文に渡す。
                    //エラーにはエラーメッセージが返ってくる
                    string BirthDay = BirthYearList.Text + "/" + BirthMonthList.Text + "/" + BirthDayList.Text;
                    string Join = JoinYearList.Text + "/" + JoinMonthList.Text + "/" + JoinDayList.Text;
                    error = ID.Insert(TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text, TextBox5.Text, int.Parse(DropDownList1.Text), BirthDay, DropDownList2.Text, Join);

                }
                catch (FormatException)
                {
                    error = "未入力項目があります。";
                }
                Session.Add("msg", error);
                Server.Transfer("Result.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Add("gender", DropDownList1.Text);
            Server.Transfer("Menu.aspx");
        }
        protected void Birth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int days = 31;

            int M = int.Parse(BirthMonthList.Text);
            switch (M)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:

                    days = 31;
                    break;
                case 2:
                    int year = int.Parse(BirthYearList.Text);
                    if (year % 400 == 0)
                    {
                        days = 29;
                    }
                    else if (year % 100 == 0)
                    {
                        days = 28;

                    }
                    else if (year % 4 == 0)
                    {
                        days = 29;

                    }
                    else
                    {
                        days = 28;

                    }

                    break;
                case 4:
                case 6:
                case 9:
                case 11:

                    days = 30;
                    break;
            }
            BirthDayList.Items.Clear();
            for (int i = 1; i <= days; i++)
            {
                BirthDayList.Items.Add(i.ToString());

            }
        }

        //入社日の年月を選択したとき、その年月に対応した日数に変更します
        protected void Join_SelectedIndexChanged(object sender, EventArgs e)
        {
            int days = 31;

            int M = int.Parse(JoinMonthList.Text);
            switch (M)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:

                    days = 31;
                    break;
                case 2:
                    int year = int.Parse(JoinYearList.Text);
                    if (year % 400 == 0)
                    {
                        days = 29;
                    }
                    else if (year % 100 == 0)
                    {
                        days = 28;

                    }
                    else if (year % 4 == 0)
                    {
                        days = 29;

                    }
                    else
                    {
                        days = 28;

                    }

                    break;
                case 4:
                case 6:
                case 9:
                case 11:

                    days = 30;
                    break;
            }
            JoinDayList.Items.Clear();
            for (int i = 1; i <= days; i++)
            {
                JoinDayList.Items.Add(i.ToString());

            }

        }
    }
}