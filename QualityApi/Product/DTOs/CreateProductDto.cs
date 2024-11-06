using System.ComponentModel.DataAnnotations;

namespace QualityApi.Product.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(50, ErrorMessage = "Name must not be larger than 50 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "SKU is required")]
        [MaxLength(50, ErrorMessage = "SKU must not be larger than 50 characters")]
        public required string SKU { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [MaxLength(50, ErrorMessage = "Department must not be larger than 50 characters")]
        public required string Department { get; set; }

        [Required(ErrorMessage = "Cost price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost price must be greater than 0")]
        public required decimal CostPrice { get; set; }

        [Required(ErrorMessage = "Retail price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Retail price must be greater than 0")]
        public required decimal RetailPrice { get; set; }

        [Required(ErrorMessage = "Unit weight is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit weight must be greater than 0")]
        public required decimal UnitWeight { get; set; }
    }
}
