Imports System.Xml


Namespace OslHelpdesk


Public Class DataAccess

    '---------------------------------------------------
    ' PROPERTY: ConnectStr
    '       Looks up database connection string from
    '       XML file located in 'Database.xml'
    '---------------------------------------------------
    Public Shared _ConnectStr As String = ""

    Public ReadOnly Property ConnectStr() As String
        Get
            If _ConnectStr = "" Then ReadFromXmlFile()
            Return _ConnectStr

        End Get
    End Property



    '---------------------------------------------------
    ' PROPERTY: WebFolder
    '       Sets the location of the website
    '---------------------------------------------------
    Public Shared _WebFolder As String = ""

    Public Property WebFolder() As String
        Get
            Return _WebFolder
        End Get
        Set(ByVal Value As String)
            _WebFolder = Value
        End Set
    End Property

    '---------------------------------------------------
    ' PROPERTY: Server
    '       Database Server Name 
    '---------------------------------------------------
    Private Shared _Server As String

    Public Property Server() As String
        Get
            Return _Server
        End Get
        Set(ByVal Value As String)
            _Server = Value
        End Set
    End Property

    '---------------------------------------------------
    ' PROPERTY: Database
    '       Database Name 
    '---------------------------------------------------
    Private Shared _Database As String

    Public Property Database() As String
        Get
            Return _Database
        End Get
        Set(ByVal Value As String)
            _Database = Value
        End Set
    End Property

    '---------------------------------------------------
    ' PROPERTY: UserName
    '        Server UserName 
    '---------------------------------------------------
    Private Shared _Username As String

    Public Property Username() As String
        Get
            Return _Username
        End Get
        Set(ByVal Value As String)
            _Username = Value
        End Set
    End Property

    '---------------------------------------------------
    ' PROPERTY: Password
    '       Database Server Password 
    '---------------------------------------------------
    Private Shared _Password As String

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property


    Private Sub ReadFromXmlFile() 'for use for reading the xml file and outputting it to the public shared properties
        Dim enc As System.Text.UTF8Encoding
        dim obj as New OSL.Utils.Encryption.Encryption64
        Dim rd As New XmlTextReader(WebFolder & "/database.xml")

        While rd.Read ' while rs reads a line
            Select Case rd.Name
                Case "xml", "", "DatabaseDetails"
                    'do nothing
                Case "Server"
                    _Server = rd.ReadString
                Case "Database"
                    _Database = rd.ReadString
                Case "Username"
                    _Username = rd.ReadString
                Case "Password"
                    _Password = rd.ReadString
            End Select

        End While 'move to next line

        rd.Close()

        'the following is formatting the values so that the server can actually understand it when it is passed in
        _ConnectStr = "Data source=" & obj.Decrypt(_Server, "sunshine") & ";initial catalog=" & obj.Decrypt(_Database, "sunshine") & ";User ID=" & obj.Decrypt(_Username, "sunshine") & ";Password=" & obj.Decrypt(_Password, "sunshine")
    End Sub
    Public Sub WriteToXMLFile()

        Dim enc As New System.Text.UTF8Encoding
        Dim wr As New XmlTextWriter(_WebFolder & "\database.xml", enc)

        With wr

            'Set up XML document
            .Formatting = Formatting.Indented
            .WriteStartDocument()

            '--------------------------------------------------
            ' Add the following xml to the file:
            '
            ' <DatabaseDetails>
            ' <Server>.</Server>
            ' <Database>bhf/bhf</Database>
            ' <Username>bhfrda</Username>
            ' <Password>password</Password>
            ' </DatabaseDetails>
            '--------------------------------------------------

            'Table name
            .WriteStartElement("DatabaseDetails")

            '1st field and value
            .WriteStartElement("Server")
            .WriteString(_Server)
            .WriteEndElement()

            '2nd field and value
            .WriteStartElement("Database")
            .WriteString(_Database)
            .WriteEndElement()

            '3rd field and value
            .WriteStartElement("Username")
            .WriteString(_Username)
            .WriteEndElement()

            '4th field and value
            .WriteStartElement("Password")
            .WriteString(_Password)
            .WriteEndElement()

            .WriteEndElement()
            .Close()

        End With
        wr = Nothing
    End Sub

End Class
End Namespace
