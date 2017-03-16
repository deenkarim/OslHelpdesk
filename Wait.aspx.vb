Namespace OslHelpdesk

Partial Class Wait1
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
        '//// SAMPLE
        ' Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=listusers.aspx"">"
        '//// SAMPLE

        ' Set Redirection URL
        ltMetatag.Text = Session("UrlRedirect")
        ' Set Error Message to display
        lblError.Text = Session("UserInsertMSG") + ", You will be now be redirected."
        'Remove all sessions
        Session.Remove("UserInsertMSG")
        Session.Remove("UrlRedirect")
    End Sub

End Class

End Namespace
