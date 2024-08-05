using FinalProjectLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectWabAPI.DTOs
{
    public class PaymentDto
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string CardNumber { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [StringLength(35)]
        public string Surname { get; set; }
        [Required]
        [StringLength(26, MinimumLength = 26)]
        public string AccountNumber { get; set; }
        [Required]
        [Range(0, 200.00)]
        public decimal Amount { get; set; }
        [StringLength(140, MinimumLength = 140)]
        public string DetailsOfPayments { get; set; }
    }
}


