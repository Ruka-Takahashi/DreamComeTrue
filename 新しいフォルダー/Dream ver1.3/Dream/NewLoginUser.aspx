<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewLoginUser.aspx.cs" Inherits="Dream.NewLoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="CSS/NewLoginUser.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>夢創造委員会</h1>
        <h2>ログインユーザー登録画面</h2>
        <table>
            <tr><td align="left">ユーザーID：</td><td align="left"><asp:TextBox ID="ID_TextBox" runat="server"></asp:TextBox><br /></td></tr>
            <tr><td align="left">パスワード：</td><td align="left"> <asp:TextBox ID="PW_TextBox" runat="server"></asp:TextBox><br /></td></tr>
        </table>
        <br />
        <asp:Button ID="CreateUser_Button" runat="server" Text="登録" OnClick="CreateUser_Button_Click" />
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br />
            <span class="span2">The Dream Creation Committee</span></p>

    </form>
</body>
</html>
