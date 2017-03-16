Imports System.Data.SqlClient


Namespace OslHelpdesk


Public Class comment

    Public Function GetComments(ByVal TicketID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT u.FullName AS CommentFrom, c.Comment, c.DateLogged " & _
                             "FROM tblcomment as c INNER JOIN " & _
                             "tblUser as u ON c.UserID = u.UserID " & _
                             "Where c.TicketID = " & TicketID & _
                             "Order By DateLogged Desc"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("Comments")

        cn.Open()
        da.Fill(ds, "Comments")
        cn.Close()

        Return ds
    End Function

    Public Function AddComment(ByVal TicketID, ByVal Comment, ByVal UserID, ByVal DateLogged) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "INSERT INTO tblComment " & _
                             "(TicketID, Comment, UserID, DateLogged) VALUES " & _
                             "('" & TicketID & "', '" & Comment & "', '" & UserID & "', '" & DateLogged & "')"

        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function

End Class

End Namespace
