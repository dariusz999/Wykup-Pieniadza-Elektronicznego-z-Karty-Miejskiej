using System.ComponentModel.DataAnnotations;

namespace FinalProjectWabAPI.DTOs
{
    public class CustomerDto
    {
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

