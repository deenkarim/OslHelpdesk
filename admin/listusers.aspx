<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.listusers" CodeFile="listusers.aspx.vb" %>
<!-- #include file="layout/headerusers.html" -->
<form id="Form1" method="post" runat="server">
	<font size="5" color="#000000"><b>Users</b></font><BR>
	<BR>
	<br>
	<font size="3" face="verdana" color="#000000">Search for 
		user:&nbsp;&nbsp;&nbsp;&nbsp;</font>
	<asp:TextBox id="txtSearch" runat="server" Width="280px" />&nbsp;&nbsp;
	<asp:Button id="btnSearch" runat="server" Text="Search" CssClass="button" />&nbsp;
	<asp:Button id="btnViewAll" runat="server" Text="View All" CssClass="button" />
	<br>
	<br>
	<asp:Button id="btnEdit" runat="server" Text="View/Edit" CssClass="button" />&nbsp;
	<asp:Button id="btnDelete" runat="server" CssClass="button" Text="Delete"></asp:Button>
	<br>
	<br>
	<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
	<br>
	<asp:DataGrid id="dgUsers" runat="server" BorderColor="#DEDFDE" BackColor="White" Height="0px"
		Width="800px" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
		ForeColor="Black">
		<FooterStyle BackColor="#CCCC99"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
		<Columns>
			<asp:BoundColumn Visible="False" DataField="UserID"></asp:BoundColumn>
			<asp:TemplateColumn>
				<ItemTemplate>
					<asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="FullName" HeaderText="Full Name"></asp:BoundColumn>
		</Columns>
		<PagerStyle NextPageText="Next Page" PrevPageText="Previous Page" HorizontalAlign="Right" ForeColor="Black"
			BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
	</asp:DataGrid>
	<br>
	<P></P>
</form>
<!-- #include file="../layout/footer.html" -->
