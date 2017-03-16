Namespace OslHelpdesk

Partial Class clticket
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
        Dim ticket As New ticket
        Dim cltickets As New DataSet
        Dim usr As New user

        cltickets = ticket.GetClosedTicketsUser(usr.UserID)

        dgClosed.DataSource = cltickets.Tables("OpenTickets")
        dgClosed.DataBind()
    End Sub

    Private Sub btnTickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("opticket.aspx")
    End Sub

    Private Sub btnClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("clticket.aspx")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("adticket.aspx")
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("usercp.aspx")
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("default.aspx")
    End Sub

    Private Sub dgClosed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgClosed.SelectedIndexChanged

    End Sub
End Class

End Namespace
