Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography

Namespace OslHelpdesk.OSL.Utils.Encryption
    ' Uses DES private key and vector to provide HTTP / XMLDOM - safe base64 string encryption
    ' Encrypted string such as account info, passwords, etc can be safely placed in XML element
    ' for transmission over the wire without any illegal characters

    ' Author: Peter Bromberg
    ' Date:   3/12/02
    ' Last Modified: 3/12/02

    Public Class Encryption64

        ' Use DES CryptoService with Private key pair
        Private key() As Byte = {} ' we are going to pass in the key portion in our method calls
        Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}

        Public Function Decrypt(ByVal stringToDecrypt As String, ByVal sEncryptionKey As String) As String

            Dim inputByteArray(stringToDecrypt.Length) As Byte

            ' Note: The DES CryptoService only accepts certain key byte lengths
            ' We are going to make things easy by insisting on an 8 byte legal key length

            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))

            Dim des As New DESCryptoServiceProvider

            ' we have a base 64 encoded string so first must decode to regular unencoded (encrypted) string
            inputByteArray = Convert.FromBase64String(stringToDecrypt)

            ' now decrypt the regular string
            Dim ms As New MemoryStream

            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)

            cs.FlushFinalBlock()

            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8

            Return encoding.GetString(ms.ToArray())

        End Function

        Public Function Encrypt(ByVal stringToEncrypt As String, ByVal SEncryptionKey As String) As String

            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))

            Dim des As New DESCryptoServiceProvider

            ' convert our input string to a byte array
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(stringToEncrypt)

            'now encrypt the bytearray
            Dim ms As New MemoryStream

            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write)

            cs.Write(inputByteArray, 0, inputByteArray.Length)

            cs.FlushFinalBlock()

            ' now return the byte array as a "safe for XMLDOM" Base64 String
            Return Convert.ToBase64String(ms.ToArray())
        End Function

    End Class
End Namespace