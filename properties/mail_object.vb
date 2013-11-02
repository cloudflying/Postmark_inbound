Imports Newtonsoft.Json
Public Class mail_object
    Public Property From As String
    Public Property FromFull As FromFull
    <JsonProperty("To")> _
    Public Property [To] As String
    Public Property ToFull As List(Of ToFull)
    Public Property Cc As String
    Public Property CcFull As List(Of CcFull)
    Public Property ReplyTo As String
    Public Property Subject As String
    Public Property MessageID As String
    <JsonProperty("Date")> _
    Public Property [Date] As String
    Public Property MailboxHash As String
    Public Property TextBody As String
    Public Property replyMsg As String
    Public Property HtmlBody As String
    Public Property Tag As String
    Public Property Headers As List(Of Header)
    Public Property Attachments As List(Of Attachment)
End Class

Public Class FromFull
    Public Property email As String
    Public Property name As String
End Class

Public Class ToFull
    Public Property Email As String
    Public Property Name As String
End Class

Public Class CcFull
    Public Property Email As String
    Public Property Name As String
End Class

Public Class Header
    Public Property Name As String
    Public Property Value As String
End Class
Public Class Attachment
    Public Property Name As String
    Public Property Content As String
    Public Property ContentType As String
    Public Property ContentLength As Integer
End Class
