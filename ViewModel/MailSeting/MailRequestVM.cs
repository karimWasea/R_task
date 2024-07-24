using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.MailSeting
{
    public class MailRequestVM
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        public  DateTime  DateTime { get; set; }
        [Required]
        public string Body { get; set; }
        //public IList<IFormFile> Attachments { get; set; }
         
    }
}
