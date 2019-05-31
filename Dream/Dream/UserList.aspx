<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Dream.UserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="CSS/UseList.css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>夢創造委員会</h1>
        <h2>ユーザー一覧</h2>

<div style=" width: 806px;
    height: 236px;
    /*background: #888;*/
    margin: 0 auto;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="emp_cd" DataSourceID="m_employee" GridLines="None" Width="809px">
            <Columns>
                <asp:BoundField DataField="emp_cd" HeaderText="従業員コード" ReadOnly="True" SortExpression="emp_cd" />
                <asp:BoundField DataField="last_nm" HeaderText="氏" SortExpression="last_nm" />
                <asp:BoundField DataField="first_nm" HeaderText="名" SortExpression="first_nm" />
                <asp:BoundField DataField="last_nm_kana" HeaderText="氏(ふりがな)" SortExpression="last_nm_kana" />
                <asp:BoundField DataField="first_nm_kana" HeaderText="名(ふりがな)" SortExpression="first_nm_kana" />
                <asp:BoundField DataField="gender_nm" HeaderText="性別" SortExpression="gender_nm" />
                <asp:BoundField DataField="birth_date" DataFormatString="{0:yyyy/MM/dd}" HeaderText="誕生日" SortExpression="birth_date" />
                <asp:BoundField DataField="section_nm" DataFormatString="{0:yyyy/MM/dd}" HeaderText="所属部署名" SortExpression="section_nm" />
                <asp:BoundField DataField="emp_date" DataFormatString="{0:yyyy/MM/dd}" HeaderText="入社日" SortExpression="emp_date" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
</div>
<div>
        <asp:SqlDataSource ID="m_employee" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString2 %>" SelectCommand="SELECT m_employee.emp_cd, m_employee.last_nm, m_employee.first_nm, m_employee.last_nm_kana, m_employee.first_nm_kana, m_gender.gender_nm, m_employee.birth_date, m_section.section_nm, m_employee.emp_date FROM m_employee INNER JOIN m_gender ON m_employee.gender_cd = m_gender.gender_cd INNER JOIN m_section ON m_employee.section_cd = m_section.section_cd"></asp:SqlDataSource>
        <br />

        従業員コードを選択してください。<asp:DropDownList ID="Emp_Cd_List" runat="server" DataSourceID="SqlDataSource1" DataTextField="emp_cd" DataValueField="emp_cd" Height="25px" Width="155px">
        </asp:DropDownList>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString3 %>" SelectCommand="SELECT [emp_cd] FROM [m_employee]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="UpDateButton" runat="server" Text="更新" OnClick="UpDateButton_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="削除" OnClick="DeleteButton_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="戻る" name="Back_button" OnClick="Button1_Click"/>
</div>        
        <br />
        <hr />

       <p>＠<span class="span1">夢創造委員会</span><br /><span class="span2">The Dream Creation Committee</span></p>
       
            </form>
</body>
</html>
