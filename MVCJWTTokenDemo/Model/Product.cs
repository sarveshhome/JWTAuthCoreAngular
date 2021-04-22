using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJWTTokenDemo.Model
{
    public class Product
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
