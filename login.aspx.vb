Imports System.Web.Security


Namespace OslHelpdesk

Partial Class login
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim data As New DataAccess
        ' Set path of Webfolder
        data.WebFolder = Server.MapPath("")

        'Dim obj As New OSL.Utils.Encryption.Encryption64

        'Label5.Text = "database: " & obj.Encrypt("osl-srv1", "sunshine")

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim usr As New user
        Dim Authed As Boolean

        Authed = usr.ValidUser(txtUsername.Text, txtPassword.Text)

        If Authed = True Then
            FormsAuthentication.SetAuthCookie(txtUsername.Text, False)
            If usr.UserLevel = 1 Then
                Response.Redirect("admin/default.aspx")
            Else
                Response.Redirect("default.aspx")
            End If

        Else
            LblError.Visible = True

        End If
    End Sub
End Class

End Namespace
