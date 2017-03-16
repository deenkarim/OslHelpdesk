Namespace OslHelpdesk

Partial Class addeditusers
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
            Dim u As New user
            u.UserEditID = Request.Params("UserEditID")
            If u.UserEditID = "" Then
                lblUser.Text = "Add User"
                PopulateForAdd()
            Else
                lblUser.Text = "Edit User"
                PopulateAll()
            End If
        End If

    End Sub
    '/////// Fills form for adding a new user 
    Function PopulateForAdd()
        PopulateUserTypes()
        PopulateCompany()
        Me.ddlUserType.SelectedValue = "2"
    End Function
    '/////// Fills form with user details for editing
    Function PopulateAll()
        PopulateUserTypes()
        PopulateCompany()
        PopulateUserForEdit()
    End Function
    Function PopulateUserTypes()
        Dim u As New user
        Dim ds As DataSet

        ds = u.GetUserTypes
        ddlUserType.DataSource = ds
        ddlUserType.DataValueField = "UserTypeID"
        ddlUserType.DataTextField = "UserType"
        ddlUserType.DataBind()
    End Function
    Function PopulateCompany()
        Dim u As New user
        Dim ds As DataSet

        ds = u.GetCompany
        ddlCompany.DataSource = ds
        ddlCompany.DataValueField = "CompanyID"
        ddlCompany.DataTextField = "CompanyName"
        ddlCompany.DataBind()

    End Function
    Function PopulateUserForEdit()
        Dim u As New user
        Dim ds As DataSet

        ds = u.GetUser(u.UserEditID)

        With ds.Tables(0).Rows(0)
            Me.txtUserName.Text = .Item("UserName").ToString
            Me.txtFullName.Text = .Item("FullName")
            Me.txtEmail.Text = .Item("Email")
            Me.txtTel.Text = .Item("Telephone")
            Me.ddlUserType.SelectedValue = .Item("UserTypeID")
            Me.ddlCompany.SelectedValue = .Item("CompanyID")
            Session("Password") = .Item("Password")
        End With


    End Function

    Function InsertUpdateUser()
        Try
            Dim u As New user
            Dim ds As DataSet

            If u.UserEditID = "" Then
                ' check if users already exists in tblUser
                ds = u.CheckEmail(txtEmail.Text)
                If ds.Tables(0).Rows.Count = 0 Then
                    'Insert a new user into tblUser
                    u.InsertUser(Me.txtUserName.Text, Me.txtFullName.Text, Me.txtEmail.Text, _
                        Me.txtTel.Text, Me.ddlCompany.SelectedValue, Me.ddlUserType.SelectedValue, "password")
                    'Set conformation message and redirect
                    Session("UserInsertMSG") = "User added successfully"
                    Response.Redirect("wait.aspx")
                Else
                    'If user already exists display an error
                    If u.UserEditID = "" Then
                        lblError.Text = "User already exists"
                    End If
                End If

            Else
                'Updates a new user into tblUser
                u.UpdateUser(u.UserEditID, Me.txtUserName.Text, Me.txtFullName.Text, Me.txtEmail.Text, _
                        Me.txtTel.Text, Me.ddlCompany.SelectedValue, Me.ddlUserType.SelectedValue, Session("Password"))
                'Set conformation message and redirect
                Session("UserInsertMSG") = "User updated successfully"
                Session.Remove("password")
                Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=listusers.aspx"">"
                Response.Redirect("wait.aspx")
            End If

        Catch ex As Exception
            lblError.Text = "Problem inserting/updating user, please try again. Error: " + ex.Message
        End Try
    End Function

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        InsertUpdateUser()
    End Sub
End Class
End Namespace
