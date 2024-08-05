using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibrary.Models
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [StringLength(35)]
        public string Surname { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Pesel { get; set; }
    }
}