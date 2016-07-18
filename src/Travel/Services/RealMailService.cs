using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Services
{
    public class RealMailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            Console.WriteLine($"Sending mail: To: {to}, Subject: {subject}");
            return true;
        }
    }
}
