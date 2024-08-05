using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLibrary.Models
{
    public class CardValidator
    {

        [Required]
        [StringLength(26, MinimumLength = 26)]
        public string CardAccountNumber { get; set; }
        [Required]
        [Range(0, 200.00)]
        public decimal Amount { get; set; }
        public bool CardPaid { get; set; }
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
