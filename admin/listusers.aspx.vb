Namespace OslHelpdesk

Partial Class listusers
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
  

    Private Sub btnViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAll.Click
        Me.txtSearch.Text = ""
        lblError.Visible = False
        PopulateUser()
    End Sub

    Function PopulateUser()
        Dim u As New user
        Dim ds As DataSet

        ds = u.GetUsers()
        dgUsers.DataSource = ds
        dgUsers.DataBind()

    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.txtSearch.Text.Length = 0 Then
            lblError.Visible = True
            lblError.Text = "Nothing to search"
        Else
            lblError.Visible = False
            Dim u As New user
            Dim ds As DataSet

            ds = u.SearchUser(txtSearch.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                dgUsers.DataSource = ds
                dgUsers.DataBind()
            Else
                ds = Nothing
                lblError.Visible = True
                lblError.Text = "No users found, please redefine your search"
            End If
        End If
        Me.txtSearch.Text = ""
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim da As New DataAccess
        Dim objItem As DataGridItem

        For Each objItem In Me.dgUsers.Items

            ' Ignore invalid items
            If objItem.ItemType <> ListItemType.Header And _
                objItem.ItemType <> ListItemType.Footer And _
                objItem.ItemType <> ListItemType.Pager Then

                ' Retrieve the value of the check box
                Dim blnEdit As Boolean

                blnEdit = CType(objItem.Cells(1).FindControl("chkSelect"), CheckBox).Checked

                If blnEdit = True Then
                    Response.Redirect("addeditusers.aspx?UserEditID=" & objItem.Cells(0).Text)
                End If
            End If
        Next

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.txtSearch.Text = ""
        lblError.Visible = False

        Dim u As New user
        Dim objItem As DataGridItem
        Dim UserID As Integer


        For Each objItem In Me.dgUsers.Items

            ' Ignore invalid items
            If objItem.ItemType <> ListItemType.Header And _
                objItem.ItemType <> ListItemType.Footer And _
                objItem.ItemType <> ListItemType.Pager Then

                ' Retrieve the value of the check box
                Dim blnDelete As Boolean

                blnDelete = CType(objItem.Cells(1).FindControl("chkSelect"), CheckBox).Checked

                If blnDelete = True Then
                    UserID = objItem.Cells(0).Text
                    'Deletes All selected Users
                    u.DeleteUser(UserID)

                End If
            End If
        Next
        Session("UserInsertMSG") = "User removed successfully"
        Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""4;URL=listusers.aspx"">"
        Response.Redirect("wait.aspx")
    End Sub
End Class

End Namespace
