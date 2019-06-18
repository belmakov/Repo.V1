using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaciTech.Apartment.Database.Models
{
    public class RoleFeature
    {
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

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
