using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace servicesstag.Model
{
    public class Email
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Emails { get; set; }

        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
