<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dream.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="CSS/login.css" />

<title>ログイン画面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>夢創造委員会</h1>
        <h2>ログイン</h2>
        <p>ユーザID：<asp:TextBox  ID="TextBox1" runat="server"  Height="20px" Width="150px"></asp:TextBox>
        </p>
        <p>パスワード：<asp:TextBox  ID="TextBox2" runat="server"  Height="20px" Width="135px" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" CssClass="corsol" runat="server" Text="ログイン" OnClick="Button1_Click" name="In_button"/>
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>

    </div>
    </form>
</body>
</html>
