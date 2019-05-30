<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpDateUser.aspx.cs" Inherits="Dream.UpDateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/UpDateUser.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>夢創造委員会</h1>
        <h2>従業員情報更新画面</h2>
        <asp:Label ID="user" runat="server" Text="Label"></asp:Label>さんを更新します。
        <br />
        <table>
            <tr><td align="left">氏：</td><td align="left"><asp:TextBox ID="last_nm" runat="server"></asp:TextBox></td></tr>
            <tr><td align="left">氏(ふりがな):</td><td align="left"><asp:TextBox ID="last_nm_kana" runat="server"></asp:TextBox></td></tr>
            <tr><td align="left">名：</td><td align="left"><asp:TextBox ID="first_nm" runat="server"></asp:TextBox></td></tr>
            <tr><td align="left">名(ふりがな)：</td><td align="left"><asp:TextBox ID="first_nm_kana" runat="server"></asp:TextBox></td></tr>
            <tr><td align="left"> 性別：</td><td align="left"> <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="m_gender" DataTextField="gender_nm" DataValueField="gender_cd">
                    </asp:DropDownList></td></tr> <asp:SqlDataSource ID="m_gender" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [gender_cd], [gender_nm] FROM [m_gender]"></asp:SqlDataSource>
                     <asp:SqlDataSource ID="m_section" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [section_cd], [section_nm] FROM [m_section]"></asp:SqlDataSource>
            <tr><td align="left"> 所属部署：</td><td align="left"> <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="m_section" DataTextField="section_nm" DataValueField="section_cd">
                    </asp:DropDownList></td></tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br />
            <span class="span2">The Dream Creation Committee</span></p>


    </form>
</body>
</html>
