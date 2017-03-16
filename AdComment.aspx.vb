Namespace OslHelpdesk

Partial Class AdComment
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

    Private Sub btnAddComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddComment.Click
        Dim comment As New comment
        Dim user As New user
        Dim ticketID As Integer
        ticketID = Session("TicketID")
        Session("TicketID") = ""

        Dim datelogged As String

        datelogged = Format(DateTime.Now, "long date") & " " & Format(DateTime.Now, "long time")

        comment.AddComment(ticketID, Replace(Replace(txtComment.Text, "'", "''"), "chr34", "chr34 chr34"), user.UserID, datelogged)

        Dim email As New email

        email.SendEmail("stevep@objectiveservices.com", "commentaddedadmin", ticketID, ticketID)

        'Redirect User back to ticket
        Dim url As String
        url = "vticket.aspx?TicketID=" & ticketID & "&mode=cadded"

        Session("UserInsertMSG") = "Comment added"
        Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=" & url & """ > "
        Response.Redirect("Wait.aspx")



    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim ticketID As Integer
        ticketID = Session("TicketID")
        Session("TicketID") = ""
        ' Redirect User back to ticket
        Response.Redirect("vticket.aspx?TicketID=" & ticketID & "&mode=cadded")

    End Sub
End Class

End Namespace
