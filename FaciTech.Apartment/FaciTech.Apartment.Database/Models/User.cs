using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaciTech.Apartment.Database.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        public String Comments { get; set; }
        [Required]
        public Boolean Inactive { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }
        [Required]
        public DateTime Updated { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid? ContactId { get; set; }
        public Contact Contact { get; set; }

        public IList<UserGroup> UserGroups { get; set; }
    }
}
