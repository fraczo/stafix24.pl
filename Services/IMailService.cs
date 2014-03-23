using System;
using System.Net.Mail;
namespace stafix24.pl.Services
{
    public interface IMailService
    {
        bool SendMail(string from, string to, string subject, string body);
    }
}
