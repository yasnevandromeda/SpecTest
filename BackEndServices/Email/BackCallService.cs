using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BackEndServices
{
    public interface IBackCallService
    {
        public Task SendBackCall(string userName, string phone, string email, int userType);
    }

    public class BackCallService : IBackCallService
    {
        private const string CorpYandexMail = "specialist.corp@yandex.ru";
        private const string UserYandexMail = "specialist.ufl@yandex.ru";

        public BackCallService()
        {
        
        }

        public async Task SendBackCall(string userName, string phone, string email, int userType)
        {
            if (!IsValidEMail(email))
                throw new ApplicationException("Неверный email");
            if (!IsValidPhone(phone))
                throw new ApplicationException("Неверный телефон");


            var smtp = new SmtpProvider();
            string subject = "Запланирован обратный звонок";
            string body = $"На номер {phone} пользователю {userName}";
            try
            {
                smtp.SendEMail(email, subject, body);
            }
            catch(ApplicationException ex)
            {
                string backupEmail = (userType == 1) ? CorpYandexMail : UserYandexMail; 
                smtp.SendMailUsingYandex(backupEmail, subject, body);
            }


        }

        public bool IsValidEMail(string email)
        {
            bool isValid = Regex.IsMatch(email, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", RegexOptions.IgnoreCase);
            return isValid;
        }


        public bool IsValidPhone(string phone)
        {
            bool isValid = Regex.IsMatch(phone, @"^\+?[1-9]\d{0,3}[-. ]?\(?\d{1,4}\)?[-. ]?\d{1,4}[-. ]?\d{1,9}$", RegexOptions.IgnoreCase);
            return isValid;
        }
                

    }
}
