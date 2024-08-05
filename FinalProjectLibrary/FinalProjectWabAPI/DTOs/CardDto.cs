using System.ComponentModel.DataAnnotations;

namespace FinalProjectWabAPI.DTOs
{
    public class CardDto
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string CardNumber { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(26, MinimumLength = 26)]
        public string CardAccountNumber { get; set; }
        [Required]
        [Range(0, 200.00)]
        public decimal Amount { get; set; }
    }
}
