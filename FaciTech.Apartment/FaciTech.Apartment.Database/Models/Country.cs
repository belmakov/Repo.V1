using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaciTech.Apartment.Database.Models
{
    public class Country
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
        public String Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}
