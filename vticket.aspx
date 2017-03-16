<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.vticket" CodeFile="vticket.aspx.vb" %>
<!-- #include file="layout/headerviewticket.html" -->
<form id="Form1" method="post" runat="server">
	<table border="0" cellpadding="4" cellspacing="4" height="532">
		<tr>
			<td colspan="2">
				<font size="5" color="#000000"><b>View Ticket</b></font>
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Label ID="lblMode" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>Logged By</td>
			<td><asp:Label ID="lblFullName" runat="server" Font-Bold="True"></asp:Label></td>
		</tr>
		<tr>
			<td>Phone Number</td>
			<td><asp:Label ID="lblPhoneno" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Ticket Title</td>
			<td><asp:Label ID="lblTickettitle" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>Priority</td>
			<td>
				<asp:Label id="lblPriority" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
		</tr>
		<tr>
			<td vAlign="top">Error Message You Recieve</td>
			<td><asp:Label ID="LblErrorMessage" runat="server" Height="112px" Width="368px"></asp:Label></td>
		</tr>
		<tr>
			<td vAlign="top">Description of what happened</td>
			<td><asp:Label ID="LblDescription" runat="server" Height="152px" Width="368px"></asp:Label></td>
		</tr>
		<tr>
			<td>Machine Number</td>
			<td><asp:Label ID="lblMachineNumber" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td>
			</td>
			<td align="right">&nbsp;
				<asp:Button ID="btnClose" runat="server" Text="Close Ticket" CssClass="button" />&nbsp;
				<asp:Button ID="btnAddComment" runat="server" Text="Add Comment" CssClass="button" />&nbsp;
				<asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="button" />
			</td>
		</tr>
	</table>
	<BR>
	<font size="5" color="#000000"><b>Comments</b></font><BR>
	<BR>
	<asp:DataGrid id="dgComments" runat="server" Height="0px" Width="808px" BackColor="White" BorderColor="#DEDFDE"
		BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AutoGenerateColumns="False"
		ForeColor="Black">
		<FooterStyle BackColor="#CCCC99"></FooterStyle>
		<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
		<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
		<ItemStyle BackColor="#F7F7DE"></ItemStyle>
		<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
		<Columns>
			<asp:BoundColumn DataField="CommentFrom" HeaderText="From"></asp:BoundColumn>
			<asp:BoundColumn DataField="Comment" HeaderText="Comment"></asp:BoundColumn>
			<asp:BoundColumn DataField="DateLogged" HeaderText="Date Added"></asp:BoundColumn>
		</Columns>
		<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
	</asp:DataGrid>
</form>
<!-- #include file="layout/footer.html" -->
