﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Dream.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="CSS/Result.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>夢創造委員会</h1>
        <h2><asp:Label  ID="Label1" runat="server" Text="Label"></asp:Label><br /></h2>
        <asp:Button CssClass="corsol" ID="Button1" runat="server" Text="戻る" OnClick="Button1_Click" />
        <br />
        <hr />
        <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>
    </form>
</body>
</html>
