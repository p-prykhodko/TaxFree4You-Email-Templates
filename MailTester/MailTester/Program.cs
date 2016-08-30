using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = @"..\..\MailTemplates\taxfree2.html";

            var client = new SmtpClient("mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("fa6098eec55199", "f6554503eced6f"),
                EnableSsl = true
            };

            var from = "no-reply@taxfree.eu";
            var to = "ayavorskiy.runme@previews.emailonacid.com";
            //var to = "to@example.com";
            var subject = "TaxFree";

            var message = "";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                var text = sr.ReadToEnd();
                message = text;

                Console.WriteLine(text);
            }

            MailMessage mail = new MailMessage(from, to, subject, message);
            mail.IsBodyHtml = true;

            client.Send(mail);
            Console.WriteLine("===================================================Sent====================================================================");
            Console.ReadLine();
        }
    }
}