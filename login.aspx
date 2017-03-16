<%@ Page Language="vb" AutoEventWireup="false" Inherits="OslHelpdesk.login" CodeFile="login.aspx.vb" %>
<HTML>
	<HEAD>
		<title>Objective Services Limited - Login</title>
	</HEAD>
	<BODY bgColor="#edebe3">
		<form id="Form1" method="post" runat="server">
			<font face="verdana" color="#000000" size="11">
				<table cellpadding="10" cellspacing="0" bordercolor="#000000" align="center" width="400"
					border="1">
					<tr>
						<td>
							<TABLE border="0" cellPadding="2" cellSpacing="2" id="Table1" width="400">
								<TBODY>
									<TR>
										<TD colspan="3"><img src="layout/images/objectivelogo.gif"></TD>
									</TR>
									<TR>
										<TD colspan="3">
											<asp:Label ID="LblError" runat="server" Font-Names="Verdana" Font-Size="14px" Font-Bold="True"
												ForeColor="Red" Visible="False">Please login to continue</asp:Label></TD>
									</TR>
									<TR>
										<TD height="28" width="162">
											<font face="verdana" color="#000000" size="2">Email:</font></TD>
										<TD height="28"><asp:textbox id="txtUsername" runat="server" Width="290px" Font-Size="12px" Font-Names="Verdana"
												BorderStyle="Groove"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="162" height="27">
											<font face="verdana" color="#000000" size="2">Password:</font></TD>
										<TD height="27">
											<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="290px" Font-Size="12px"
												Font-Names="Verdana" BorderStyle="Groove"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="right" colspan="2" height="26"><asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" BackColor="LightSteelBlue"
												BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Size="12px" Font-Names="Verdana"></asp:Button></TD>
									</TR>
									<tr>
										<td colspan="2" align="left">
											<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please enter a username"
												Font-Size="14px" Font-Names="Verdana"></asp:RequiredFieldValidator>
											<br>
											<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password"
												Font-Size="14px" Font-Names="Verdana"></asp:RequiredFieldValidator>
										</td>
									</tr>
								</TBODY>
							</TABLE>
						</td>
					</tr>
				</table>
		</form>
		</FONT>
	</BODY>
</HTML>
