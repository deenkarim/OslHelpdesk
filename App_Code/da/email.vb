Namespace OslHelpdesk

Public Class email

    Public Function SendEmail(ByVal EmailTo, ByVal Mode, ByVal ExtraSubject, ByVal Extrabody)

        Dim mailObj As New Mail.MailMessage

        mailObj.From = "stevep@objectiveservices.com"
        mailObj.To = EmailTo
        mailObj.Priority = Mail.MailPriority.High

        If Mode = "ticketadded" Then
            mailObj.Subject = "A new Ticket has been added"
            mailObj.Body = "A new ticket has been added with the title " & Extrabody & _
                           "Please login to http://www.oslhelpdesk.co.uk/ to view this ticket."
        End If

        If Mode = "ticketaddedadmin" Then
            mailObj.Subject = "A new Ticket has been added"
            mailObj.Body = "A new ticket has been added with the title " & Extrabody & _
                           "Please login to http://osl-srv1/ to view this ticket."
        End If

        If Mode = "commentAdded" Then
            mailObj.Subject = "A new Comment has been added to #" & ExtraSubject
            mailObj.Body = "A new comment has been added to #" & Extrabody & _
                           "Please login to http://www.oslhelpdesk.co.uk/ to view this ticket."
        End If

        If Mode = "commentAddedadmin" Then
            mailObj.Subject = "A new Comment has been added to " & ExtraSubject
            mailObj.Body = "A new comment has been added to #" & Extrabody & _
                           "Please login to http://osl-srv1/ to view this ticket."
        End If

        If Mode = "newuser" Then
            mailObj.Subject = "Welcome to Oslhelpdesk.co.uk! " & ExtraSubject
            mailObj.Body = "Welcome to the oslhelpdesk! please login with the following details: " & vbCrLf & Extrabody & _
                           "Please login to http://www.oslhelpdesk.co.uk/ to view this ticket."
        End If

        If Mode = "assigned" Then
            mailObj.Subject = "A ticket has been assigned to you " & ExtraSubject
            mailObj.Body = "the ticket number #" & Extrabody & " has been assigned to you." & _
                           "Please login to http://www.oslhelpdesk.co.uk/ to view this ticket."
        End If

        If Mode = "resolved" Then
            mailObj.Subject = "#" & ExtraSubject & " has now been marked as resolved"
            mailObj.Body = "The ticket number #" & Extrabody & " has now been marked as resolved." & _
                           "Please login to http://www.oslhelpdesk.co.uk/ to either add additional comments (which will reopen the ticker), or to close this ticket."
        End If

        Try
            Mail.SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("mainsmtp")
            Mail.SmtpMail.Send(mailObj)
        Catch ex As Exception
            Try

                Mail.SmtpMail.SmtpServer = ConfigurationSettings.AppSettings("secondsmtp")
                Mail.SmtpMail.Send(mailObj)
            Catch ex2 As Exception
                Throw ex2
            End Try
        End Try

    End Function

End Class

End Namespace
