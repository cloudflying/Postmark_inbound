Imports System.Net
Imports System.IO
Imports Newtonsoft.Json

Public Class postmark_inbound

    Public Function ParseInbound(emailContent As Stream) As mail_object
        Try
            Dim reader As New System.IO.StreamReader(emailContent)
            Dim storeEMail As String = reader.ReadToEnd
            Dim Email As mail_object = JsonConvert.DeserializeObject(Of mail_object)(storeEMail)
            Return Email
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function



End Class
