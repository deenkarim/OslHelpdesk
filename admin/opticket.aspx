<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.opticket1" CodeFile="opticket.aspx.vb" %>
<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
<!-- #include file="layout/headeropenticket.html" -->
<form id="Form1" method="post" runat="server">
	<font color="#000000" size="5"><b>Open Tickets</b></font><BR>
	<BR>
	<asp:datagrid id="dgOpen" runat="server" ForeColor="Black" BorderStyle="None" BorderWidth="1px"
		CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False" BorderColor="#DEDFDE" BackColor="White"
		Height="16px" Width="800px">
		<FooterStyle BackColor="#CCCC99"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Ticket Number">
				<ItemTemplate>
							<a href='vticket.aspx?TicketID=<%# DataBinder.Eval(Container, "DataItem.TicketID") %>'>
						<%# DataBinder.Eval(Container, "DataItem.TicketID") %>
					</a></asp:HyperLink>	
					</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="TicketTitle" HeaderText="Ticket Title"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Logged Date">
				<ItemTemplate>
					<asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateLogged", "{0:dd/MM/yyyy}") %>'>
					</asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Priority" HeaderText="Priority"></asp:BoundColumn>
			<asp:BoundColumn DataField="AssignedTo" HeaderText="Assigned To"></asp:BoundColumn>
		</Columns>
		<PagerStyle NextPageText="Next Page" PrevPageText="Previous Page" HorizontalAlign="Right" ForeColor="Black"
			BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
	</asp:datagrid><BR>
	<font color="#000000" size="5"><b>Resolved Tickets</b></font><BR>
	<BR>
	<asp:datagrid id="dgResolveda" runat="server" ForeColor="Black" BorderStyle="None" BorderWidth="1px"
		CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False" BorderColor="#DEDFDE" BackColor="White"
		Height="16px" Width="800px">
		<FooterStyle BackColor="#CCCC99"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Ticket Number">
				<ItemTemplate>
<A href='vticket.aspx?TicketID=<%# DataBinder.Eval(Container, "DataItem.TicketID") %>'>
						<%# DataBinder.Eval(Container, "DataItem.TicketID") %>
					</A></ASP:HYPERLINK>
						</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="TicketTitle" HeaderText="Ticket Title"></asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Logged Date">
				<ItemTemplate>
					<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateLogged", "{0:dd/MM/yyyy}") %>'>
					</asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn DataField="Priority" HeaderText="Priority"></asp:BoundColumn>
			<asp:BoundColumn DataField="AssignedTo" HeaderText="Assigned To"></asp:BoundColumn>
		</Columns>
		<PagerStyle NextPageText="Next Page" PrevPageText="Previous Page" HorizontalAlign="Right" ForeColor="Black"
			BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
	</asp:datagrid></form>
<!-- #include file="../layout/footer.html" -->
