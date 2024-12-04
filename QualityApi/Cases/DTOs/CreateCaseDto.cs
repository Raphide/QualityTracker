using System.ComponentModel.DataAnnotations;

namespace QualityApi.Cases.DTOs
{
    public class CreateCaseDto
    {
        [Required(ErrorMessage = "Product ID is required")]
        public required long ProductId { get; set; }
        [Required(ErrorMessage = "Case must have a description")]
        [MaxLength(200, ErrorMessage = "Description must not be any larger that 200 words")]
        public required string Description { get; set; }

        // public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public required int Quantity { get; set; }

        [Required(ErrorMessage = "Location ID is required")]
        public required long LocationId { get; set; }

        // [Required(ErrorMessage = "IsActive status is required")]
        // public required bool IsActive { get; set; }

        // [MaxLength(100, ErrorMessage = "Outcome must not be larger than 100 characters")]
        // public string? Outcome { get; set; }

        // [Range(0, double.MaxValue, ErrorMessage = "Recovered cost must be a non-negative number")]
        // public decimal? RecoveredCost { get; set; }
    }
}
