using System.ComponentModel.DataAnnotations;

namespace P1WebApi.DTOs
{
    public class CustomeDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
