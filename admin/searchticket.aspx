<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.searchticket" CodeFile="searchticket.aspx.vb" %>
<!-- #include file="layout/headersearchticket.html" -->
<form id="Form1" method="post" runat="server">
	<font color="#000000" size="5"><b>Search Tickets</b></font>
	<p></p>
	<font face="verdana" color="#000000" size="3">Search 
		tickets:&nbsp;&nbsp;&nbsp;&nbsp;</font>
	<asp:textbox id="txtSearch" runat="server" Width="280px"></asp:textbox>&nbsp;&nbsp;
	<asp:checkbox id="chkSQL" runat="server" Text="SQL String " ForeColor="Black"></asp:checkbox>&nbsp;
	<asp:button id="btnSearch" runat="server" Text="Search" CssClass="button"></asp:button>&nbsp;
	<p></p>
	<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label><asp:datagrid id="dgSearch" runat="server" Width="800px" ForeColor="Black" Visible="False" AutoGenerateColumns="False"
		GridLines="Vertical" CellPadding="4" BorderWidth="1px" BorderStyle="None" Height="0px" BackColor="White" BorderColor="#DEDFDE">
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
					</A>
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
	</asp:datagrid></form>
<!-- #include file="../layout/footer.html" -->
