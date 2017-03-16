Namespace OslHelpdesk

Partial Class assignticket
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
        If Not IsPostBack Then
            PopulateUsers()
        End If
    End Sub

    Function PopulateUsers()

        Dim u As New user
        Dim t As New ticket
        Dim dsTicket As DataSet
        Dim dsUser As DataSet

        dsTicket = t.GetAssignedUser(Session("TicketID"))
        If dsTicket.Tables(0).Rows.Count = 0 Then
            lblCurrentUser.Text = "None"
        Else
            lblCurrentUser.Text = dsTicket.Tables(0).Rows(0).Item("FullName").ToString
        End If

        dsUser = u.GetOSLUsers()
        ddlUsers.DataSource = dsUser
        ddlUsers.DataValueField = "UserID"
        ddlUsers.DataTextField = "FullName"
        ddlUsers.DataBind()

    End Function
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim ticketID As Integer
        ticketID = Session("TicketID")
        Session("TicketID") = ""
        ' Redirect User back to ticket
        Response.Redirect("vticket.aspx?TicketID=" & ticketID & "&mode=cadded")
    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click

        ' Update Ticket ID with Asssigned UserID
        Dim t As New ticket
        t.AssignUser(ddlUsers.SelectedValue, Session("TicketID"))
        
        ' Set Ticket ID
        Dim ticketID As Integer
        ticketID = Session("TicketID")
        Session("TicketID") = ""

        ' Redirect User back to ticket
        Dim url As String
        url = "vticket.aspx?TicketID=" & ticketID & "&mode=cadded"

        Session("UserInsertMSG") = "User Assigned successfully"
        Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=" & url & """ > "
        Response.Redirect("Wait.aspx")
    End Sub
End Class

End Namespace
