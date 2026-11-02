using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices
{
    public class SmtpProvider
    {
        public SmtpProvider()
        { 
        }

        public void SendEMail(string email, string theme, string body)
        {
            Console.WriteLine("send email");
            throw new ApplicationException("");
        }

        public void SendMailUsingYandex(string email, string theme, string body)
        {
            Console.WriteLine("send email");
        }

    }
}
