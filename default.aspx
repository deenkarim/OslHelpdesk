<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk._default" CodeFile="default.aspx.vb" %>
<!-- #include file="layout/headerhome.html" -->
<form id="Form1" method="post" runat="server">
	<font size="5" color="#000000"><b>Open Tickets</b></font><BR>
	<BR>
	<asp:DataGrid id="dgOpen" runat="server" Width="800px" BackColor="White" BorderColor="#DEDFDE"
		BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
		Height="0px" ForeColor="Black">
		<FooterStyle BackColor="#CCCC99"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
		<HeaderStyle 	Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
		<Columns>
			<asp:TemplateColumn HeaderText="Ticket Number">
				<ItemTemplate>
							<a href='vticket.aspx?TicketID=<%# DataBinder.Eval(Container, "DataItem.TicketID") %>
'>
						<%# DataBinder.Eval(Container, "DataItem.TicketID") %>
					</a></asp:HyperLink> 
</ItemTemplate>
				<EditItemTemplate>
					<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TicketID") %>'>
					</asp:TextBox>
				</EditItemTemplate>
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
	</asp:DataGrid>
</form>
<!-- #include file="layout/footer.html" -->
