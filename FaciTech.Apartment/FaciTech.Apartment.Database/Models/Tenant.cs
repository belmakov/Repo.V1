using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaciTech.Apartment.Database.Models
{
    public class Tenant
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
        public Guid ContactId { get; set; }
        [Required]
        public Contact Contact { get; set; }
        [Required]
        public Boolean Primary { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        [Required]
        public Unit Unit { get; set; }

    }
}
