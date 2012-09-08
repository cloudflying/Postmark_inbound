Imports System.Net
Imports System.IO
Imports Newtonsoft.Json

Public Class postmark_inbound

    '
    ' #### Postmark-Inbound class library
    ' #### Created by Justin Porter
    ' #### Attribution 3.0 Unported (CC BY 3.0)
    ' #### License: http://creativecommons.org/licenses/by/3.0/
    ' #### view us on github: https://github.com/cloudflying/Postmark_inbound
    ' #### Enjoy!

    ' #### version 0.1 alpha
    ' #### initial work



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
            Return Email
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function



End Class
