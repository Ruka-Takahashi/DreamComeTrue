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
    <h1>夢創造委員会</h1>
    <h2>ログインユーザー登録画面</h2>
        <p>
            <asp:Label ID="Error" runat="server" Text="Label"></asp:Label>
        </p>
        <table>
            <tr><th align="left">ユーザーID：</th><th align="left"> <asp:TextBox ID="ID_TextBox" runat="server"></asp:TextBox></th></tr>
            <tr><th align="left">パスワード：</th><th align="left"><asp:TextBox ID="PW_TextBox" runat="server" TextMode="Password"></asp:TextBox><br /></th></tr>
            <tr><th align="left">パスワード(確認用)：</th><th align="left"> <asp:TextBox ID="PW_Check" runat="server" TextMode="Password"></asp:TextBox></th></tr>        
        </table>
                 
        <br />
        <asp:Button ID="CreateUser_Button" runat="server" Text="登録" OnClick="CreateUser_Button_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="戻る" />
    </div>
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>
    </form>
</body>
</html>
