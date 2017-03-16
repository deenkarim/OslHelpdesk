<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.adticket" CodeFile="adticket.aspx.vb" %>
<!-- #include file="layout/headeraddticket.html" -->
<form id="Form1" method="post" runat="server">
	<table width="745" border="0" cellpadding="1" cellspacing="0">
		<tr>
			<td colspan="2">
				<font size="5" color="#000000"><b>Add A Ticket</font></B>
				<br>
			</td>
		</tr>
		<TR>
			<TD>User
			</TD>
			<TD>
				<asp:DropDownList id="ddlUsers" runat="server"></asp:DropDownList></TD>
		</TR>
		<TR>
			<TD width="180" height="24">Ticket Title</TD>
			<TD width="549" height="24">
				<asp:TextBox id="txtTicketTitle" runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="368px"></asp:TextBox>
				<asp:Label id="ertitle" runat="server" Visible="False" ForeColor="Red">*</asp:Label></TD>
		</TR>
		<TR>
			<td>Priority</td>
			<td><asp:DropDownList ID="ddlPriority" runat="server" Width="216px">
					<asp:ListItem Value="0" Selected="True">None</asp:ListItem>
					<asp:ListItem Value="1">Low</asp:ListItem>
					<asp:ListItem Value="2">Medium</asp:ListItem>
					<asp:ListItem Value="3">High</asp:ListItem>
					<asp:ListItem Value="4">Urgent</asp:ListItem>
				</asp:DropDownList></td>
		</TR>
		<tr>
			<td vAlign="top">Error Message You Recieve</td>
			<td><asp:TextBox id="txtTicketError" runat="server" Width="368px" Height="104px" Font-Size="X-Small"
					Font-Names="Verdana" TextMode="MultiLine"></asp:TextBox></td>
		</tr>
		<tr>
			<td vAlign="top">Description of what happened</td>
			<td><asp:TextBox ID="txtTicketDescription" runat="server" Font-Names="Verdana" Font-Size="X-Small"
					Width="368px" TextMode="MultiLine" Height="144px"></asp:TextBox><asp:Label id="erDescription" runat="server" ForeColor="Red" Visible="False">*</asp:Label></td>
		</tr>
		<tr>
			<td>Machine Number</td>
			<td><asp:TextBox ID="txtTicketMachine" runat="server" Font-Names="Verdana" Font-Size="X-Small" Width="368px"></asp:TextBox></td>
		</tr>
		<tr>
			<td></td>
			<td>
				<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" />&nbsp;&nbsp;</td>
		</tr>
	</table>
</form>
<asp:Label id="lblError" runat="server" Visible="False" Font-Bold="True" ForeColor="Red" Font-Size="X-Small"
	Font-Names="Verdana">Please fill in all fields marked with *</asp:Label>
<!-- #include file="layout/footer.html" -->
