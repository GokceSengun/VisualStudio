using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Mail için özet açıklama
/// </summary>

public static class Mail
{
    //mail gönderme methodu
    public static string SENDER = ""; //gönderenin mail adresi
    public static string MAILPASSWORD = ""; //şifresi

    public static bool Send(string subject, string content,string reciver)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(SENDER); //gonderen
        mail.To.Add(reciver);//alıcı
        mail.Subject = subject;
        mail.Body = content;

        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new System.Net.NetworkCredential(SENDER, MAILPASSWORD);
        smtp.Port = 587;
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        object userState = mail;
        mail.IsBodyHtml = true;

        smtp.Send(mail);

        return true;
    }
}