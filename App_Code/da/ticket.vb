Imports System.Data.SqlClient


Namespace OslHelpdesk


Public Class ticket

    Public Function GetOpenTicketsUser(ByVal UserID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where t.UserID = " & UserID & " AND t.Status = 'O'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("OpenTickets")

        cn.Open()
        da.Fill(ds, "OpenTickets")
        cn.Close()

        Return ds
    End Function

    Public Function GetResolvedTicketsUser(ByVal UserID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where t.UserID = " & UserID & " AND t.Status = 'R'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("resolved")

        cn.Open()
        da.Fill(ds, "resolved")
        cn.Close()

        Return ds
    End Function

    Public Function GetClosedTicketsUser(ByVal UserID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where t.UserID = " & UserID & " AND t.Status = 'C'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("OpenTickets")

        cn.Open()
        da.Fill(ds, "OpenTickets")
        cn.Close()

        Return ds
    End Function

    Public Function GetOpenTicketsAdmin() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where Status = 'O'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("OpenTickets")

        cn.Open()
        da.Fill(ds, "OpenTickets")
        cn.Close()

        Return ds
    End Function

    Public Function GetClosedTicketsAdmin() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where Status = 'C'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("OpenTickets")

        cn.Open()
        da.Fill(ds, "OpenTickets")
        cn.Close()

        Return ds
    End Function

    Public Function GetResolvedTicketsAdmin() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                             "From tblTicket as t " & _
                             "left join tblUser as u on t.AssignedTo = u.UserID " & _
                             "Where Status = 'R'"

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("Resolved")

        cn.Open()
        da.Fill(ds, "Resolved")
        cn.Close()

        Return ds
    End Function

    Public Function GetTicket(ByVal TicketID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "SELECT t.TicketTitle, t.Priority, t.ErrorMessage, t.Description, t.MachineNo, u.FullName, u.Telephone " & _
                             "From tblTicket as t " & _
                             "LEFT join tblUser as u on t.UserID = u.UserID " & _
                             "Where TicketID = " & TicketID

        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("Ticket")

        cn.Open()
        da.Fill(ds, "Ticket")
        cn.Close()

        Return ds
    End Function

    Public Function ResolveTicket(ByVal TicketID)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "UPDATE tblTicket SET Status = 'R' " & _
                             "Where TicketID = " & TicketID

        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Function

    Public Function CloseTicket(ByVal TicketID)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "UPDATE tblTicket SET Status = 'C' " & _
                             "Where TicketID = " & TicketID

        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Function

    Public Function OpenTicket(ByVal TicketID)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "UPDATE tblTicket SET Status = 'O' " & _
                             "Where TicketID = " & TicketID

        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Function

    Public Function OpenNewTicket(ByVal TicketTitle, ByVal Priority, ByVal ErrorMessage, ByVal Description, ByVal MachineNo, ByVal UserID)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "INSERT INTO tblTicket (TicketTitle, Priority, ErrorMessage, Description, MachineNo, UserID, DateLogged, Status) Values ('" & TicketTitle & _
                             "', '" & Priority & "', '" & ErrorMessage & "', '" & Description & "', '" & MachineNo & "', '" & UserID & "', '" & Format(DateTime.Now, "long date") & "', 'O')"
        Dim cmd As New SqlCommand(sSQL, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

    End Function
    '------------------------------------------------------
    '       Assign User to Ticket
    '------------------------------------------------------
    Function AssignUser(ByVal UserID As Integer, _
                        ByVal TicketID As Integer)

        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "UPDATE tblTicket " & _
                               "SET AssignedTo= '" & UserID & "' " & _
                                "WHERE TicketID=" & TicketID

        Dim cmd As New SqlCommand(sSql, cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function
    '------------------------------------------------------
    '       Get Assigned User
    '------------------------------------------------------
    Function GetAssignedUser(ByVal TicketID As Integer) As DataSet

        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT u.FullName  FROM tblTicket as t " & _
                             "LEFT JOIN tblUser as u on t.AssignedTo=u.UserID " & _
                             "WHERE TicketID =" & TicketID


        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("AssignedUser")

        cn.Open()
        da.Fill(ds, "AssignedUser")
        cn.Close()

        Return ds
    End Function
    '------------------------------------------------------
    '       Return Ticket based on user search
    '------------------------------------------------------
    Public Function SearchTickets(ByVal Search As String, ByVal SQLString As String) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)

        Dim sSQL As String
        sSQL = ""

        If SQLString = 1 Then
            sSQL = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, assigned.Fullname as AssignedTo " & _
                            "FROM tblTicket as t " & _
                            "LEFT JOIN tblUser as assigned on t.AssignedTo=assigned.UserID " & _
                            "LEFT JOIN tblUser as username on t.UserID=username.UserID " & _
                            "WHERE " & Search
        Else

            sSQL = "SELECT t.TicketID, t.TicketTitle, t.DateLogged, t.Priority, u.Fullname as AssignedTo " & _
                            "FROM tblTicket as t " & _
                            "LEFT JOIN tblUser as u on t.AssignedTo=u.UserID " & _
                            "LEFT JOIN tblUser as uu on t.UserID=uu.UserID " & _
                            "WHERE (t.TicketTitle LIKE '%" & Search & "%') " & _
                            "OR (t.ErrorMessage LIKE '%" & Search & "%') " & _
                            "OR (t.Description LIKE '%" & Search & "%') " & _
                            "OR (t.MachineNo LIKE '%" & Search & "%') " & _
                            "OR (u.FullName LIKE '%" & Search & "%') " & _
                            "OR (uu.FullName LIKE '%" & Search & "%') "
        End If

        Dim cmd As New SqlCommand(sSQL, cn)
        Dim da As New SqlDataAdapter(sSQL, cn)
        Dim ds As New DataSet("Search")

        cn.Open()
        da.Fill(ds, "Search")

        Return ds
    End Function
End Class

End Namespace
