using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIPractice.Model
{
    public interface IEmployee
    {
        [Required]
        public string Name { get; set; }
        
        public int Age{ get; set; }
        
        public string Address { get; set; }

        public string Phone{ get; set; }
    }
}
