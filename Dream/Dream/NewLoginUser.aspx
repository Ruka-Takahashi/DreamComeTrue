<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewLoginUser.aspx.cs" Inherits="Dream.NewLoginUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/NewLoginUser.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>ログインユーザー登録画面</h1>
        <p>
            <asp:Label ID="Error" runat="server" Text="Label"></asp:Label>
        </p>

        ユーザーID：<asp:TextBox ID="ID_TextBox" runat="server"></asp:TextBox><br />
        パスワード：<asp:TextBox ID="PW_TextBox" runat="server"></asp:TextBox><br />

        <asp:Button ID="CreateUser_Button" runat="server" Text="登録" OnClick="CreateUser_Button_Click" />
    </div>
    </form>
</body>
</html>
