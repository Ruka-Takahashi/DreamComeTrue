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
            従業員コード</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="検索" />
        </p>
        <p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="emp_cd" DataSourceID="Search2" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="emp_cd" HeaderText="従業員コード" ReadOnly="True" SortExpression="emp_cd" />
                    <asp:BoundField DataField="last_nm" HeaderText="氏" SortExpression="last_nm" />
                    <asp:BoundField DataField="first_nm" HeaderText="名" SortExpression="first_nm" />
                    <asp:BoundField DataField="last_nm_kana" HeaderText="氏(ふりがな)" SortExpression="last_nm_kana" />
                    <asp:BoundField DataField="first_nm_kana" HeaderText="名(ふりがな)" SortExpression="first_nm_kana" />
                    <asp:BoundField DataField="birth_date" HeaderText="生年月日" SortExpression="birth_date" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="emp_date" HeaderText="入社日" SortExpression="emp_date" DataFormatString="{0:yyyy/MM/dd}" />
                    <asp:BoundField DataField="gender_nm" HeaderText="性別" SortExpression="gender_nm" />
                    <asp:BoundField DataField="section_nm" HeaderText="所属部署" SortExpression="section_nm" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="該当するデータがありません。"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <asp:SqlDataSource ID="Search2" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT m_employee.emp_cd, m_employee.last_nm, m_employee.first_nm, m_employee.last_nm_kana, m_employee.first_nm_kana, m_employee.birth_date, m_employee.emp_date, m_gender.gender_nm, m_section.section_nm FROM m_employee INNER JOIN m_gender ON m_employee.gender_cd = m_gender.gender_cd INNER JOIN m_section ON m_employee.section_cd = m_section.section_cd
WHERE [emp_cd] = @emp_cd">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="emp_cd" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
        所属部署<br />
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="section" DataTextField="section_nm" DataValueField="section_cd" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        </p>
        <asp:SqlDataSource ID="section" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT [section_cd], [section_nm] FROM [m_section]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="emp_cd" DataSourceID="Search" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="emp_cd" HeaderText="従業員コード" ReadOnly="True" SortExpression="emp_cd" />
                <asp:BoundField DataField="last_nm" HeaderText="氏" SortExpression="last_nm" />
                <asp:BoundField DataField="first_nm" HeaderText="名" SortExpression="first_nm" />
                <asp:BoundField DataField="last_nm_kana" HeaderText="氏(ふりがな)" SortExpression="last_nm_kana" />
                <asp:BoundField DataField="first_nm_kana" HeaderText="名(ふりがな)" SortExpression="first_nm_kana" />
                <asp:BoundField DataField="gender_nm" HeaderText="性別" SortExpression="gender_nm" />
                <asp:BoundField DataField="section_nm" HeaderText="所属部署" SortExpression="section_nm" />
                <asp:BoundField DataField="birth_date" HeaderText="生年月日" SortExpression="birth_date" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField DataField="emp_date" HeaderText="入社日" SortExpression="emp_date" DataFormatString="{0:yyyy/MM/dd}" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="Label2" runat="server" Text="該当するデータがありません。"></asp:Label>
            </EmptyDataTemplate>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <asp:SqlDataSource ID="Search" runat="server" ConnectionString="<%$ ConnectionStrings:Dream_dbConnectionString %>" SelectCommand="SELECT m_employee.emp_cd, m_employee.last_nm, m_employee.first_nm, m_employee.last_nm_kana, m_employee.first_nm_kana, m_employee.birth_date, m_employee.emp_date, m_gender.gender_nm, m_section.section_nm FROM m_employee INNER JOIN m_gender ON m_employee.gender_cd = m_gender.gender_cd INNER JOIN m_section ON m_employee.section_cd = m_section.section_cd WHERE (m_employee.section_cd = @section_cd)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="section_cd" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="戻る" />
    </div>
    </form>
</body>
</html>
