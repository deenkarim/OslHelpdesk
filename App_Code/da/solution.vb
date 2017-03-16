Imports System.Data.SqlClient


Namespace OslHelpdesk


Public Class solution

    Public Function AddSolution(ByVal Comment) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "INSERT INTO tblTicket " & _
                             "(Solution) VALUES " & _
                             "(" & Comment & ")"

        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function

    Public Function GetSolution(ByVal TicketID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT Solution FROM tblTicket WHERE TicketID = " & TicketID

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("solution")

        cn.Open()
        da.Fill(ds, "solution")
        cn.Close()

        Return ds
    End Function


End Class

End Namespace
