using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AppUserRoleId { get; set; }
        [ForeignKey("AppUserRoleId")]
        public AppUserRole Role { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}