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
        public DateTime BirthDate { get; set; }
        [Required]
        public int AppUserRoleId { get; set; }
        [ForeignKey("AppUserRoleId")]
        public AppUserRole Role { get; set; }
        /// <summary>
        /// TODO: Add Map One to One Relationship
        /// </summary>
        /// <value></value>
        public Order Order { get; set; }
        public IEnumerable<Bill> Bills { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<CreditCard> CreditCards { get; set; }
    }
}