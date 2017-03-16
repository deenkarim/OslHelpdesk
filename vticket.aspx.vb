Namespace OslHelpdesk

Partial Class vticket
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
        If Request.Params("TicketID") = "" Then
            Response.Redirect("default.aspx")
        End If

        If Not Request.Params("TicketID") = "" Then Session("TicketID") = Request.Params("TicketID")
        If Not Request.Params("mode") = "" Then
            If Request.Params("mode") = "cadded" Then
                lblMode.Text = "Comment Added"
            End If
        End If

        Dim ticket As New ticket
        Dim dsTicket As DataSet

        dsTicket = ticket.GetTicket(Request.Params("TicketID"))

        lblTickettitle.Text = dsTicket.Tables(0).Rows(0).Item("TicketTitle") & " "
        lblPriority.Text = dsTicket.Tables(0).Rows(0).Item("Priority") & " "
        LblErrorMessage.Text = dsTicket.Tables(0).Rows(0).Item("ErrorMessage") & " "
        LblDescription.Text = dsTicket.Tables(0).Rows(0).Item("Description") & " "
        lblMachineNumber.Text = dsTicket.Tables(0).Rows(0).Item("MachineNo") & " "
        lblFullName.Text = dsTicket.Tables(0).Rows(0).Item("FullName") & " "
        lblPhoneno.Text = dsTicket.Tables(0).Rows(0).Item("Telephone") & " "

        Dim comment As New comment
        Dim dsComment As New DataSet
        dsComment = comment.GetComments(Request.Params("TicketID"))
        dgComments.DataSource = dsComment
        dgComments.DataBind()


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim usr As New user

        If usr.UserLevel = 1 Then
            Response.Redirect("admin/default.aspx")
        Else
            Response.Redirect("default.aspx")
        End If

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
        Response.Redirect("AdComment.aspx")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim ticket As New ticket
        Dim usr As New user
        Dim email As New email
        Dim ds As New DataSet

        ds = usr.GetUser(usr.UserID)
        ticket.ResolveTicket(Session("TicketID"))
        email.SendEmail(ds.Tables(0).Rows(0).Item("Email"), "resolved", Session("TicketID"), Session("TicketID"))


        If usr.UserLevel = 1 Then
            ticket.ResolveTicket(Session("TicketID"))
            Session("UserInsertMSG") = "Ticket closed"
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=admin/default.aspx"">"
            Response.Redirect("Wait.aspx")
        Else

            ticket.CloseTicket(Session("TicketID"))
            Session("UserInsertMSG") = "Ticket closed"
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=default.aspx"">"
            Response.Redirect("Wait.aspx")
        End If
    End Sub

End Class

End Namespace
