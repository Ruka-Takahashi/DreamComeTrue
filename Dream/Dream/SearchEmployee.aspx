<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs" Inherits="Dream.SearchEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
        所属部署<br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="section" DataTextField="section_nm" DataValueField="section_cd" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        </p>
        <asp:SqlDataSource ID="section" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [section_cd], [section_nm] FROM [m_section]"></asp:SqlDataSource>
        <p>

        </p>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="emp_cd" DataSourceID="Search">
            <Columns>
                <asp:BoundField DataField="emp_cd" HeaderText="従業員コード" ReadOnly="True" SortExpression="emp_cd" />
                <asp:BoundField DataField="last_nm" HeaderText="氏" SortExpression="last_nm" />
                <asp:BoundField DataField="first_nm" HeaderText="名" SortExpression="first_nm" />
                <asp:BoundField DataField="last_nm_kana" HeaderText="氏(ふりがな)" SortExpression="last_nm_kana" />
                <asp:BoundField DataField="first_nm_kana" HeaderText="名(ふりがな)" SortExpression="first_nm_kana" />
                <asp:BoundField DataField="gender_nm" HeaderText="性別" SortExpression="gender_nm" />
                <asp:BoundField DataField="section_nm" HeaderText="所属部署" SortExpression="section_nm" />
                <asp:BoundField DataField="birth_date" HeaderText="生年月日" SortExpression="birth_date" DataFormatString="{0:yyyy/MM/ss}" />
                <asp:BoundField DataField="emp_date" HeaderText="入社日" SortExpression="emp_date" DataFormatString="{0:yyyy/MM/ss}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Search" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT m_employee.emp_cd, m_employee.last_nm, m_employee.first_nm, m_employee.last_nm_kana, m_employee.first_nm_kana, m_employee.birth_date, m_employee.emp_date, m_gender.gender_nm, m_section.section_nm FROM m_employee INNER JOIN m_gender ON m_employee.gender_cd = m_gender.gender_cd INNER JOIN m_section ON m_employee.section_cd = m_section.section_cd WHERE (m_employee.section_cd = @section_cd)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="section_cd" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
    </form>
</body>
</html>
