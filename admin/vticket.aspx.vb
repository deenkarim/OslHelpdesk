Namespace OslHelpdesk

Partial Class vticket1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label


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
        Dim priority As String
        priority = ""
        With dsTicket.Tables(0).Rows(0)
            If .Item("Priority") = "4" Then
                priority = "Urgent"
            End If
            If .Item("Priority") = "3" Then
                priority = "High"
            End If
            If .Item("Priority") = "2" Then
                priority = "Medium"
            End If
            If .Item("Priority") = "1" Then
                priority = "Low"
            End If
            If .Item("Priority") = " " Then
                priority = "None"
            End If

        End With

        lblPriority.Text = priority
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
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=default.aspx"">"
            Response.Redirect("Wait.aspx")
        Else

            ticket.CloseTicket(Session("TicketID"))
            Session("UserInsertMSG") = "Ticket closed"
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=default.aspx"">"
            Response.Redirect("Wait.aspx")
        End If
    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        Response.Redirect("assignticket.aspx")
    End Sub
End Class

End Namespace
