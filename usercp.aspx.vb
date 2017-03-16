Namespace OslHelpdesk

Partial Class usercp
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim u As New user
        Dim ds As DataSet
        ds = u.GetUser(u.UserID)
        lblUser.Text = ds.Tables(0).Rows(0).Item("FullName")
    End Sub

    Function CheckPassword() As Boolean
        Dim u As New user
        Dim Result As String
        Result = u.CheckPassword(Me.txtOldPass.Text, u.UserID)
        Return Result
    End Function
    Function UpdatePassword()
        Try
            If Me.txtNewPass.Text.Length < 6 Then
                lblError.Text = "Password is not long enough, must be at least 6 characters"
            Else

                If CheckPassword() = True Then

                    If txtNewPass.Text = txtNewPass2.Text Then
                        Dim u As New user
                        u.UpdatePassword(u.UserID, Me.txtNewPass.Text)

                    Else
                        lblError.Text = "New password does not match"
                    End If
                Else
                    lblError.Text = "Old password does not match"
                End If
            End If

        Catch ex As Exception
            lblError.Text = "Error updating password, please try again. Error: " + ex.Message
        End Try
    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtNewPass.Text = ""
        Me.txtNewPass2.Text = ""
        Me.txtOldPass.Text = ""
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        UpdatePassword()
        Session("UserInsertMSG") = "Password updated successfully"
        Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=default.aspx"">"
        Response.Redirect("Wait.aspx")
    End Sub
End Class

End Namespace
