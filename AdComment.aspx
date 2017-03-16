<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.AdComment" CodeFile="AdComment.aspx.vb" %>
<!-- #include file="layout/headerviewticket.html" -->
<form id="Form1" method="post" runat="server">
	<TABLE id="Table1" cellSpacing="4" cellPadding="4" width="580" border="0">
		<TR>
			<TD colSpan="3">
				<font size="5" color="#000000"><b>Add A Comment</b></font><BR>
			</TD>
		</TR>
		<TR>
			<TD vAlign="top">
				Comment</TD>
			<TD colSpan="2" align="right">
				<asp:TextBox id="txtComment" runat="server" Height="200px" Width="472px" TextMode="MultiLine" /></TD>
		</TR>
		<TR>
			<TD align="right"></TD>
			<TD align="right">
				<asp:Button id="btnAddComment" runat="server" Text="Add Comment" CssClass="button" />&nbsp;&nbsp;
				<asp:Button id="btnCancel" runat="server" Text="Back" CssClass="button" /></TD>
		</TR>
	</TABLE>
</form>
<asp:Label id="lblError" runat="server" Font-Bold="True" Font-Size="X-Small" Font-Names="Verdana"
	Visible="False" ForeColor="Red">Please fill in all fields marked with *</asp:Label>
<!-- #include file="layout/footer.html" -->
