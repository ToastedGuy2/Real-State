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
        public string FullName { get; set; }

        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}