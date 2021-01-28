using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("AppUserRole")]
    public class AppUserRole
    {
        [Key]
        public int AppUserRoleId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<AppUser> Users { get; set; }
    }
}