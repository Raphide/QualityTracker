using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Locations.Entities
{
    [Table("locations")]
    public class Location
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Range(1, 10)]
        public int Shelf { get; set; }

        [Required]
        [Range(1, 4)]
        public int Level { get; set; }

        [Required]
        [Range(1, 5)]
        public int Aisle { get; set; }

        [Required]
        [MaxLength(8)]
        public required string FullLocation { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        [JsonIgnore]
        public CaseEntity? Case { get; set; }

        public long? CaseId { get; set; }
        public void FormatLocation()
        {
            FullLocation = $"{Shelf:D2}-{Level:D2}-{Aisle:D2}";
        }
    }
}