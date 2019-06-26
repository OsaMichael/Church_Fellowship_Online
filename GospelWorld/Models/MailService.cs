using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GospelWorld.Models
{
    public class MailService
    {
        
        private string _mailTo = "evanmikeosa@yahoo.com";
        private string _mailFrom = "noreply@praiseassembly1.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with MailService");
            Debug.WriteLine($"Subject:{subject}");
            Debug.WriteLine($"Message:{message}");
        }
    }
}