using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Cases.Entities
{
    [Table("cases")]
    public class Case
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public required string CaseNumber {get; set;}
        [Required]
        public required long ProductId { get; set; }
        [Required]
        [JsonIgnore]
        public required ProductEntity Product { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Description { get; set; }

        [Required]
        public required DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }
        [Required]
        public required int Quantity { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        public string? Outcome { get; set; }
        public decimal? RecoveredCost { get; set; }

    }
}