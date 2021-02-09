using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Feature")]
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<HouseFeature> Houses { get; set; } = new List<HouseFeature>();
    }
}