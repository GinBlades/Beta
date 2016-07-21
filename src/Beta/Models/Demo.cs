using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beta.Models
{
    public class Demo
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public bool Active { get; set; }

        public DateTime PublishAt { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
    }
}
