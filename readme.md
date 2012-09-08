Welcome to our project!
=============

Description:
--------
Using the .net framework (version 4.0) we have created a simple inbound email parser for postmark. (http://www.postmarkapp.com).

How to use:
--------

Include the following

      Imports postmark_inbound

Next in your page load event:

     Dim parser As New postmark_inbound.postmark_inbound
     Dim Email_object As mail_object = parser.ParseInbound(HttpContext.Current.Request.InputStream)

That's it!

How to view the Email_Object?
----------------

The email_object we created above is a very large property library. With all the information that postmark sends you. You can view stuff using the following code:

	Email_Object.FromFull.Name
	Email_Object.FromFull.Email
	etc.....


List of All Definitions:
---------------

     From 
     FromFull (LIST SEE BELOW)
     To
     ToFull (LIST SEE BELOW)
     Cc 
     CcFull (LIST SEE BELOW)
     ReplyTo 
     Subject 
     MessageID 
     Date
     MailboxHash 
     TextBody 
     HtmlBody 
     Tag 
     Headers (LIST SEE BELOW)
     Attachments (LIST SEE BELOW)


Lists:

FromFull, ToFull, ccFull
     Email
     Name

Header
     Name
     Value

Attachment
     Name
     Content
     ContentType
     ContentLength