<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.assignticket" CodeFile="assignticket.aspx.vb" %>
<!-- #include file="layout/headerviewticket.html" -->
<form id="Form1" method="post" runat="server">
	<TABLE id="Table1" cellSpacing="4" cellPadding="4" border="0">
		<TR>
			<TD colSpan="3">
				<font color="#000000"></font><STRONG><FONT size="5">Assign Ticket</FONT></STRONG><BR>
			</TD>
		</TR>
		<tr>
			<td>
				Current Assigned User
			</td>
			<td>
				<asp:Label id="lblCurrentUser" runat="server" Font-Bold="True"></asp:Label>
			</td>
		</tr>
		<TR>
			<TD vAlign="top" width="160">
				User</TD>
			<TD colSpan="2">
				<asp:DropDownList id="ddlUsers" runat="server" Width="300px"></asp:DropDownList></TD>
		</TR>
		<TR>
			<TD align="right"></TD>
			<TD align="right">
				<asp:Button id="btnAssign" runat="server" Text="Assign" CssClass="button" />&nbsp;&nbsp;
				<asp:Button id="btnCancel" runat="server" Text="Back" CssClass="button" /></TD>
		</TR>
	</TABLE>
</form>
<asp:Label id="lblError" runat="server" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana"
	Visible="False" ForeColor="Red">Please fill in all fields marked with *</asp:Label>
<!-- #include file="../layout/footer.html" -->
