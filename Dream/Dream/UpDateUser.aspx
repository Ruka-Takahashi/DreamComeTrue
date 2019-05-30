<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpDateUser.aspx.cs" Inherits="Dream.UpDateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>従業員情報更新画面</h1>
        <asp:Label ID="user" runat="server" Text="Label"></asp:Label>さんを更新します。
        <br />
        氏：      
        <asp:TextBox ID="last_nm" runat="server"></asp:TextBox>
        <br />
        氏(ふりがな):
        <asp:TextBox ID="last_nm_kana" runat="server"></asp:TextBox>
        <br />
        名：
        <asp:TextBox ID="first_nm" runat="server"></asp:TextBox>
        <br />
        名(ふりがな)：
        <asp:TextBox ID="first_nm_kana" runat="server"></asp:TextBox>
        <br />
        性別：
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="m_gender" DataTextField="gender_nm" DataValueField="gender_cd">
        </asp:DropDownList>

        <asp:SqlDataSource ID="m_gender" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [gender_cd], [gender_nm] FROM [m_gender]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="m_section" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [section_cd], [section_nm] FROM [m_section]"></asp:SqlDataSource>
        <br />

        所属部署： 
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="m_section" DataTextField="section_nm" DataValueField="section_cd">
        </asp:DropDownList>

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="更新" OnClick="Button1_Click" />

    </form>
</body>
</html>
