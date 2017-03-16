<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.addeditusers" CodeFile="addeditusers.aspx.vb" %>
<!-- #include file="layout/headeraddusers.html" -->
<form id="Form1" method="post" runat="server">
	<table cellSpacing="0" cellPadding="1" width="500" border="0">
		<tr>
			<td colSpan="2"><asp:label id="lblUser" runat="server" Font-Size="18px" Font-Names="Verdana" Font-Bold="True"></asp:label><br>
			</td>
		</tr>
		<tr>
			<td>User Name
			</td>
			<td><asp:textbox id="txtUserName" runat="server" Width="300px"></asp:textbox></td>
		</tr>
		<tr>
			<td>Full Name
			</td>
			<td><asp:textbox id="txtFullName" runat="server" Width="300px"></asp:textbox><asp:requiredfieldvalidator id="RFVName" runat="server" ErrorMessage="*" ControlToValidate="txtFullName"></asp:requiredfieldvalidator></td>
		</tr>
		<tr>
			<td>User Type</td>
			<td><asp:dropdownlist id="ddlUserType" runat="server" Width="250px"></asp:dropdownlist></td>
		<tr>
			<td>Company</td>
			<td><asp:dropdownlist id="ddlCompany" runat="server" Width="250px"></asp:dropdownlist></td>
		</tr>
		<tr>
			<td>Email</td>
			<td><asp:textbox id="txtEmail" runat="server" Width="300px"></asp:textbox><asp:requiredfieldvalidator id="RFVEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:requiredfieldvalidator></td>
		</tr>
		<tr>
			<td>Telephone</td>
			<td><asp:textbox id="txtTel" runat="server" Width="300px"></asp:textbox></td>
		</tr>
		<tr>
			<td></td>
			<td><asp:button id="btnSubmit" runat="server" CssClass="button" Text="Submit"></asp:button>&nbsp;</td>
		</tr>
	</table>
</form>
<font color="#ff0000">* - Required Field(s)</font>
<p><asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></p>
<!-- #include file="../layout/footer.html" -->
