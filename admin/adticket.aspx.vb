Namespace OslHelpdesk

Partial Class adticket1
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
            LoadUsers()
        End If
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim aError As Boolean

        aError = False

        If txtTicketTitle.Text = "" Then
            ertitle.Visible = True
            aError = True
        Else
            ertitle.Visible = False
        End If

        If txtTicketDescription.Text = "" Then
            erDescription.Visible = True
            aError = True
        Else
            erDescription.Visible = False
        End If

        If aError = False Then
            Dim aTicket As New ticket

            aTicket.OpenNewTicket(Replace(Replace(txtTicketTitle.Text, "'", "''"), "chr34", "chr34 chr34"), ddlPriority.SelectedValue, Replace(Replace(txtTicketError.Text, "'", "''"), "chr34", "chr34 chr34"), Replace(Replace(txtTicketDescription.Text, "'", "''"), "chr34", "chr34 chr34"), Replace(Replace(txtTicketMachine.Text, "'", "''"), "chr34", "chr34 chr34"), ddlUsers.SelectedValue)
            Dim email As New email
            Dim user As New user
            Dim ds As New DataSet

            ds = user.GetUser(ddlUsers.SelectedValue)

            email.SendEmail(ds.Tables(0).Rows(0).Item("Email"), "ticketadded", " ", txtTicketTitle.Text)

            'Redirect User
            Session("UserInsertMSG") = "Ticket added successfully"
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=default.aspx"">"
            Response.Redirect("Wait.aspx")

        Else
            lblError.Text = "Please fill in all fields marked with *"
            lblError.Visible = True
        End If

    End Sub
    Public Sub LoadUsers()
        Dim User As New user
        Dim ds As New DataSet
        ds = User.GetUsers()
        ddlUsers.DataSource = ds
        ddlUsers.DataValueField = "UserID"
        ddlUsers.DataTextField = "FullName"
        ddlUsers.DataBind()
    End Sub
End Class

End Namespace
