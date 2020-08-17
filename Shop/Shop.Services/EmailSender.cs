using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace Shop.Services
{
    public class EmailSender
    {
        public int Id { get; set; }
        [Required]
        public MailAddress EmailTo { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
