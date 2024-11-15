using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Product.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public required string SKU { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Department { get; set; }
        [Required]
        public required decimal CostPrice { get; set; }
        [Required]
        public required decimal RetailPrice { get; set; }
        [Required]
        public required decimal UnitWeight { get; set; }
        [JsonIgnore]
        public ICollection<CaseEntity>? Cases { get; set; }

    }
}