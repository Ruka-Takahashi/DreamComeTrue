<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Dream.NewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/new.css" />
</head>
<body>
   <form id="form1" runat="server">
    <h1>夢創造委員会</h1>
    <h2>従業員登録画面</h2>
       <p>
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       </p>
    <div>
        <table>
            <tr><td align="left">従業員コード：</td><td align="left"><asp:TextBox ID="TextBox1" runat="server" ForeColor="#000099"></asp:TextBox>
                <asp:Label Cssclass="hissu" ID="Req1" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                <br /></td></tr>
            <tr><td align="left">氏：</td><td align="left"><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label Cssclass="hissu" ID="Req2" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                <br /></td></tr>
            <tr><td align="left">氏(ふりがな) :</td><td align="left"><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br /></td></tr>
            <tr><td align="left">名：</td><td align="left"><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:Label Cssclass="hissu" ID="Req3" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                <br /></td></tr>
            <tr><td align="left">名(ふりがな):</td><td align="left"><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br /></td></tr>
            <tr><td align="left">性別：</td><td align="left"><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" 
                     DataTextField="gender_nm" DataValueField="gender_cd" AppendDataBoundItems="True">
                     <asp:ListItem Value="" Text="&lt;未選択&gt;" />
                     </asp:DropDownList>
                     <asp:Label  Cssclass="hissu" ID="Req4" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [gender_cd], [gender_nm] FROM [m_gender]"></asp:SqlDataSource>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [section_cd], [section_nm] FROM [m_section]"></asp:SqlDataSource>
                     </td></tr>
            <tr><td align="left"> 生年月日：</td><td align="left"> <asp:DropDownList ID="BirthYearList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Birth_SelectedIndexChanged">
                     </asp:DropDownList>
                     <asp:DropDownList ID="BirthMonthList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Birth_SelectedIndexChanged">
                     </asp:DropDownList>
                     <asp:DropDownList ID="BirthDayList" runat="server">
                     </asp:DropDownList>
                     <asp:Label Cssclass="hissu" ID="Req5" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                     </td></tr>
            <tr><td align="left">所属コード:</td><td align="left"><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="section_nm" DataValueField="section_cd">
                     </asp:DropDownList></td></tr>
            <tr><td align="left">入社日:</td><td align="left"> <asp:DropDownList ID="JoinYearList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Join_SelectedIndexChanged">
                     </asp:DropDownList>
                     <asp:DropDownList ID="JoinMonthList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Join_SelectedIndexChanged">
                     </asp:DropDownList>
                     <asp:DropDownList ID="JoinDayList" runat="server">
                     </asp:DropDownList>
                <asp:Label Cssclass="hissu" ID="Req6" runat="server" Text="Label" ForeColor="#999999"></asp:Label>
                </td></tr>

        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="登録" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="戻る" OnClick="Button2_Click" />
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>
    </div>
    </form>
</body>
</html>
