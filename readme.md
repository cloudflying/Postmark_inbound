Welcome to our project!
=============

nuget Gallery
---------
Postmark inboun is now available via nuget. (https://www.nuget.org/packages/postmark.inbound/)

Version Updates
---------
1.1.3 - nuget build deployed

1.1 - Added ReplyMsg string - Postmark_Inbound will now parse your emails and return the REPLY portion of the text body. No more parsing out the replied message.    

Verified working from the following email clients:    

Outlook 2013      

iPad / iPhone (ios 7)     

gMail     

Windows Phone 8    

(Have another email client you want us to verify / add? Create an Issue on GitHub)

New Website!
---------
View our site with more information at: http://cloudflying.github.com/Postmark_inbound/


Description:
--------
Using the .net framework (version 4.0) we have created a simple inbound email parser for postmark. (http://www.postmarkapp.com).

How to use:
--------

Create a new .aspx page in your favorite language, be it C# or vb.net. Then create a page load handler (easiest way to do this is to head over to the Designer view and double click on the white space). Include the following imports / use statements


      Imports postmark_inbound // vb.net
      using postmark_inbound; // C#

Next in your page load event:

      // vb.net
      Dim parser As New postmark_inbound.postmark_inbound
      Dim Email_object As mail_object = parser.ParseInbound(HttpContext.Current.Request.InputStream)
      // C#
      postmark_inbound.postmark_inbound parser = new postmark_inbound.postmark_inbound();
      mail_object Email_object = parser.ParseInbound(HttpContext.Current.Request.InputStream);


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
	 ReplyMsg
     HtmlBody 
     Tag 
     Headers (LIST SEE BELOW)
     Attachments (LIST SEE BELOW)


Lists:
=======

FromFull, ToFull, ccFull
--------
    Email
    Name

Header
--------
    Name
    Value

Attachment
--------
    Name
    Content
    ContentType
    ContentLength