Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions

Public Class postmark_inbound

    ' 
    ' #### Postmark-Inbound class library
    ' #### Created by Justin Porter
    ' #### Attribution 3.0 Unported (CC BY 3.0)
    ' #### License: http://creativecommons.org/licenses/by/3.0/
    ' #### view us on github: https://github.com/cloudflying/Postmark_inbound
    ' #### Enjoy!

    ' #### version 1.1
    ' #### initial work
    ' #### version 1.0 - after over 5 months of testing we have verified this system works
    ' #### version 1.1 - Added ReplyMsg option - Now view the replied body message (Plain Text Only)



    ''' <summary>
    ''' Returns Parsed Email Content
    ''' </summary>
    ''' <param name="emailContent">Send us the whole http stream using: HttpContext.Current.Request.InputStream</param>
    ''' <returns>Returns the mail_object which has all the data serialized</returns>
    ''' <remarks>version 0.1 alpha release</remarks>
    Public Function ParseInbound(emailContent As Stream) As mail_object
        Try
            Dim reader As New System.IO.StreamReader(emailContent)
            Dim storeEMail As String = reader.ReadToEnd
            Dim Email As mail_object = JsonConvert.DeserializeObject(Of mail_object)(storeEMail)

            Dim tempEmailStr As String = Email.TextBody
            Dim replyMsg As String = String.Empty
            If Len(tempEmailStr) > 0 Then
                replyMsg = replyFromOutlook(tempEmailStr)
                If Len(replyMsg) = 0 Then
                    replyMsg = replyFromios(tempEmailStr)
                End If
                If Len(replyMsg) > 0 Then
                    Email.replyMsg = replyMsg
                End If
            End If

            Return Email
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function

    Public Function ParseInboundString(emailContent As String) As mail_object
        Try
            Dim Email As mail_object = JsonConvert.DeserializeObject(Of mail_object)(emailContent)
            Return Email
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function

    ' #### Parse Replied Text Below #####
    ' #### added in version 1.1 

    Function replyFromOutlook(emailBody As String) As String
        Dim emailStr As String = String.Empty
        If InStr(LCase(emailBody), "from:", CompareMethod.Text) > 0 Then
            emailStr = Mid(emailBody, 1, InStr(LCase(emailBody), "from:") - 3)
        End If
        Return emailStr
    End Function


    Function replyFromios(emailBody As String) As String
        Dim emailStr As String = String.Empty

        Dim reply1Regex As Regex = New Regex("^(On\s(.+) [\n\r] wrote:)$", RegexOptions.IgnoreCase)
        Dim reply2Regex As Regex = New Regex("^(On\s(.+)wrote:)$", RegexOptions.IgnoreCase)

        Dim matchWhole As Match = reply1Regex.Match(emailBody)
        If matchWhole.Success Then
            emailStr = Mid(emailBody, 1, matchWhole.Index)
        End If
        Dim match2Whole = reply2Regex.Match(emailBody)
        If match2Whole.Success Then
            emailStr = Mid(emailBody, 1, match2Whole.Index)
        End If

        Dim strSplt() As String = Split(emailBody, vbNewLine)
        ' ## Perform Regex Tests line-by-line ##
        If Len(emailStr) = 0 Then
            For x As Integer = 0 To UBound(strSplt) - 1
                Dim match As Match = reply1Regex.Match(strSplt(x))
                If match.Success Then
                    emailStr = subStringCalc(strSplt, x, match.Index)
                End If
                Dim match2 = reply2Regex.Match(strSplt(x))
                If match2.Success Then
                    emailStr = subStringCalc(strSplt, x, match2.Index)
                End If
                x += 1
            Next
        End If

        ' ## if regex tests above fail, attempt to update reply text using line-by-double-line comparison ##
        If Len(emailStr) = 0 Then
            For x As Integer = 0 To UBound(strSplt) - 1
                Dim match As Match = reply1Regex.Match(strSplt(x) & strSplt(x + 1))
                If match.Success Then
                    emailStr = subStringCalc(strSplt, x, match.Index)
                End If
                Dim match2 = reply2Regex.Match(strSplt(x) & strSplt(x + 1))
                If match2.Success Then
                    emailStr = subStringCalc(strSplt, x, match2.Index)
                End If
                x += 1
            Next
        End If

        Return emailStr
    End Function



    Function subStringCalc(strSplit() As String, indx As Integer, matchIndx As Integer) As String
        Dim strCalc As String = String.Empty

        For y As Integer = 0 To indx - 1
            strCalc &= strSplit(y) & vbNewLine
        Next

        strCalc &= Mid(strSplit(indx), 1, matchIndx)

        Return strCalc
    End Function

End Class
