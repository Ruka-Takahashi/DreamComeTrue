<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Dream.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/menu.css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>夢創造委員会</h1>
        <h2>メニュー</h2>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>さん、こんにちは。<br />
         <p><asp:Button  Cssclass="corsol" ID="Button1" runat="server" Text="従業員一覧" OnClick="Button1_Click" name="Emp_button"/>
          &nbsp;&nbsp;
          <asp:Button　Cssclass="corsol" ID="Button5" runat="server" Text="従業員検索" OnClick="Button5_Click" />

          &nbsp;&nbsp;&nbsp;

          <asp:Button Cssclass="corsol" ID="Button2" runat="server" OnClick="Button2_Click" Text="従業員登録" name="New_button"/>
          &nbsp;&nbsp;</p>
        <p>&nbsp;<asp:Button Cssclass="NewUser" ID="Button4" runat="server" Text="利用者登録" OnClick="Button4_Click" />
          &nbsp;&nbsp;
          
 
         <asp:Button  CssClass="Logout" ID="Button3" runat="server" Text="ログアウト"   OnClick="Button3_Click" name="Out_button"/></p>
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>

    </div>
    </form>
</body>
</html>
