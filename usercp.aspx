<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.usercp" CodeFile="usercp.aspx.vb" %>
<!-- #include file="layout/headeruserprofile.html" -->
<form id="Form1" method="post" runat="server">
	<P><font size="5" color="#000000"><b>User Profile</b></font><BR>
		<BR>
		Change Password
		<br>
		<br>
		<TABLE id="Table1" cellSpacing="0" cellPadding="1" border="0" height="88">
			<tr>
				<td height="21">
					User
				</td>
				<td height="21">
					<asp:Label id="lblUser" runat="server"></asp:Label>
				</td>
			</tr>
			<TR>
				<TD height="23">
					Old Password</TD>
				<TD height="23">
					<asp:TextBox id="txtOldPass" runat="server" TextMode="Password" />
					<asp:RequiredFieldValidator id="RFVOldPW" runat="server" ErrorMessage="*" ControlToValidate="txtOldPass"></asp:RequiredFieldValidator></TD>
			</TR>
			<TR>
				<TD>
					New Password</TD>
				<TD>
					<asp:TextBox id="txtNewPass" runat="server" TextMode="Password" />
					<asp:RequiredFieldValidator id="RFVNewPW" runat="server" ErrorMessage="*" ControlToValidate="txtNewPass"></asp:RequiredFieldValidator></TD>
			</TR>
			<TR>
				<TD>
					Retype New Password &nbsp;</TD>
				<TD>
					<asp:TextBox id="txtNewPass2" runat="server" TextMode="Password" />
					<asp:RequiredFieldValidator id="RFVNewPW2" runat="server" ErrorMessage="*" ControlToValidate="txtNewPass2"></asp:RequiredFieldValidator></TD>
			</TR>
			<tr>
				<td>
				<td align="right">
					<asp:Button id="btnAdd" runat="server" Text="Submit" CssClass="button" />&nbsp;&nbsp;
					<asp:Button id="btnClear" runat="server" Text="Clear" CssClass="button" />&nbsp;&nbsp;&nbsp;
				</td>
			</tr>
		</TABLE>
		<asp:CompareValidator id="CVNewPassword" runat="server" ErrorMessage="New password does not match" ControlToValidate="txtNewPass"
			ControlToCompare="txtNewPass2"></asp:CompareValidator>
		<br>
		<br>
		<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
		<!-- #include file="layout/footer.html" --> </FONT></P>
</form>
