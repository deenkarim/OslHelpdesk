Namespace OslHelpdesk

Partial Class searchticket
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
    Function Search()
        Try

            If Me.txtSearch.Text.Length = 0 Then
                lblError.Visible = True
                lblError.Text = "Nothing to search"
            Else
                lblError.Visible = False
            End If


            Dim t As New ticket
            Dim ds As DataSet


            If Me.chkSQL.Checked = True Then
                ds = t.SearchTickets(txtSearch.Text, 1)
            Else
                ds = t.SearchTickets(txtSearch.Text, 0)
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                dgSearch.Visible = True
                dgSearch.DataSource = ds
                dgSearch.DataBind()
            Else
                ds = Nothing
                lblError.Visible = True
                If chkSQL.Checked = True Then
                    lblError.Text = "No data found, please check sql query"
                    dgSearch.Visible = False

                Else
                    lblError.Text = "No tickets found, please refine search criteria"
                    dgSearch.Visible = False
                End If

            End If
            Me.txtSearch.Text = ""
        Catch ex As Exception
            Session("UserInsertMSG") = "Error processing sql query, please check query and try again. Error: " + ex.Message
            Session("UrlRedirect") = "<META HTTP-EQUIV=""Refresh"" CONTENT=""8;URL=searchticket.aspx"">"
            Response.Redirect("Wait.aspx")
        End Try

    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub
End Class

End Namespace
