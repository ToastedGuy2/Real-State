using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    [Table("Province")]
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<House> Houses { get; set; } = new List<House>();
    }
}