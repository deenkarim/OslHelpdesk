Imports System.Data.SqlClient


Namespace OslHelpdesk


Public Class user

    '---------------------------------------------------
    ' PROPERTY: UserID
    '      stores the UserID
    '---------------------------------------------------
    Private Shared _UserID As String

    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(ByVal Value As String)
            _UserID = Value
        End Set
    End Property

    '---------------------------------------------------
    ' PROPERTY: UserID
    '      stores the Users Level
    '---------------------------------------------------
    Private Shared _UserLevel As String

    Public Property UserLevel() As String
        Get
            Return _UserLevel
        End Get
        Set(ByVal Value As String)
            _UserLevel = Value
        End Set
    End Property
    '---------------------------------------------------
    ' PROPERTY: UserEditID
    '      stores the UserEditID
    '---------------------------------------------------
    Private Shared _UserEditID As String

    Public Property UserEditID() As String
        Get
            Return _UserEditID
        End Get
        Set(ByVal Value As String)
            _UserEditID = Value
        End Set
    End Property

    Public Sub UpdatePassword(ByVal UserID As String, ByVal Password As String)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim ssql As String = "UPDATE tblUser " & _
                               "SET Password= '" & Password & "' " & _
                                "WHERE UserID= '" & UserID & "'"
        Dim cmd As New SqlCommand(ssql, cn)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub


    Public Function CheckPassword(ByVal Password As String, ByVal UserID As String)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSQL As String = "Select password FROM tblUser " & _
                                "WHERE Password= '" & Password & "' AND UserID = '" & UserID & "'"

        Dim dr As SqlDataReader
        Dim Result As Boolean
        Dim cmd As New SqlCommand(sSQL, cn)

        cn.Open()
        dr = cmd.ExecuteReader

        If dr.Read() Then
            Result = True
        Else
            Result = False
        End If

        cn.Close()

        Return Result

    End Function

    Public Function ValidUser(ByVal UserName As String, _
                             ByVal Password As String) As Boolean

        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT UserID, UserTypeID " & _
                                "FROM tblUser " & _
                                "WHERE (Email = '" & UserName & "' AND Password = '" & Password & "') " & _
                                "OR (UserName = '" & UserName & "' AND Password = '" & Password & "') "

        Dim dr As SqlDataReader
        Dim Result As Boolean
        Dim cmd As New SqlCommand(sSql, cn)

        cn.Open()
        dr = cmd.ExecuteReader

        'if there is a record then return true
        If dr.Read() Then
            _UserID = dr.GetValue(0)
            _UserLevel = dr.GetValue(1)

            Result = True
        Else
            Result = False
        End If

        cn.Close()

        Return Result
    End Function

    Public Function GetUserTypes() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT UserTypeID, UserType From tblUserType"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("user")

        cn.Open()
        da.Fill(ds, "user")
        cn.Close()
        Return ds
    End Function

    Public Function GetCompany() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT CompanyID, CompanyName From tblCompany"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("Company")

        cn.Open()
        da.Fill(ds, "Company")
        cn.Close()
        Return ds
    End Function
    '------------------------------------------------------
    '      Get Employees from Objective Services Ltd 
    '------------------------------------------------------
    Function GetOSLUsers() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT u.userid, u.FullName FROM tblUser as u " & _
                        "LEFT JOIN tblcompany as c on u.companyid=c.companyid " & _
                        "WHERE c.companyname = 'Objective Services Limited'"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("user")

        cn.Open()
        da.Fill(ds, "user")
        cn.Close()
        Return ds
    End Function
    Public Function GetUsers() As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT UserID, FullName " & _
                                "FROM tblUser " & _
                                    "Order By FullName"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("user")

        cn.Open()
        da.Fill(ds, "user")
        cn.Close()
        Return ds
    End Function

    Public Function GetUser(ByVal UserID) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT UserID, FullName, Email, Telephone, Password, " & _
                             "UserName, CompanyID, UserTypeID " & _
                             "FROM tblUser " & _
                             "WHERE UserID = " & UserID & _
                             " Order By FullName"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("user")

        cn.Open()
        da.Fill(ds, "user")
        cn.Close()
        Return ds
    End Function

    Function SearchUser(ByVal SearchResult) As DataSet
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT UserID, FullName, Email " & _
                             "FROM tblUser " & _
                             "WHERE FullName LIKE  '%" & SearchResult & "%' " & _
                             " Order By FullName"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("user")

        cn.Open()
        da.Fill(ds, "user")
        cn.Close()
        Return ds
    End Function
    Function DeleteUser(ByVal UserID)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim ssql As String = "DELETE FROM tblUser WHERE UserID= " & UserID
        Dim cmd As New SqlCommand(ssql, cn)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function
    Public Function InsertUser(ByVal UserName As String, _
                              ByVal FullName As String, _
                              ByVal Email As String, _
                              ByVal Telephone As String, _
                              ByVal CompanyID As String, _
                              ByVal UserTypeID As String, _
                              ByVal Password As String)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)


        'Deal with potential SQL aproshophere problem
        UserName = Replace(UserName, "'", "''")
        FullName = Replace(FullName, "'", "''")
        Email = Replace(Email, "'", "''")
        Telephone = Replace(Telephone, "'", "''")

        Dim sSQL As String = "INSERT INTO tblUser " & _
                                "(UserName,FullName, Email, Telephone, CompanyID, UserTypeID, Password) " & _
                            "VALUES " & _
                             "('" & UserName & "', '" & FullName & " ', '" & Email & "', '" & Telephone & "', '" & CompanyID & "', '" & UserTypeID & "', '" & Password & "' )"


        Dim cmd As New SqlCommand(sSQL, cn)


        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.CommandText = sSQL
        cn.Close()
    End Function

    Function UpdateUser(ByVal UserID As String, _
                              ByVal UserName As String, _
                              ByVal FullName As String, _
                              ByVal Email As String, _
                              ByVal Telephone As String, _
                              ByVal CompanyID As String, _
                              ByVal UserTypeID As String, _
                              ByVal Password As String)

        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)

        'Deal with potential SQL aproshophere problem
        UserName = Replace(UserName, "'", "''")
        FullName = Replace(FullName, "'", "''")
        Email = Replace(Email, "'", "''")
        Telephone = Replace(Telephone, "'", "''")

        'Set SQL database string
        Dim ssql As String = "UPDATE tblUser " & _
                                "SET UserName = '" & UserName & "', " & _
                                    "FullName = '" & FullName & "', " & _
                                    "Email = '" & Email & "', " & _
                                    "Password = '" & Password & "', " & _
                                    "Telephone = '" & Telephone & "', " & _
                                    "CompanyID = '" & CompanyID & "', " & _
                                    "UserTypeID = '" & UserTypeID & "' " & _
                                "WHERE UserID = " & UserID.ToString

        Dim cmd As New SqlCommand(ssql, cn)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Function
    '------------------------------------------------------
    '       Checks User does not exist
    '------------------------------------------------------
    Function CheckEmail(ByVal Email As String)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT Email " & _
                             "FROM tblUser " & _
                             "WHERE Email = " & Email & _
                             " Order By FullName"

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("Email")

        cn.Open()
        da.Fill(ds, "Email")
        cn.Close()
        Return ds
    End Function
    '------------------------------------------------------
    '       Checks User is not assigned to a ticket
    '------------------------------------------------------
    Function CheckAssignedTickets(ByVal UserID As String)
        Dim db As New DataAccess
        Dim cn As New SqlConnection(db.ConnectStr)
        Dim sSql As String = "SELECT TicketID " & _
                             "FROM tblTicket " & _
                             "WHERE UserID = " & UserID

        Dim da As New SqlDataAdapter(sSql, cn)
        Dim ds As New DataSet("TicketID")

        cn.Open()
        da.Fill(ds, "TicketID")
        cn.Close()
        Return ds
    End Function

End Class

End Namespace
