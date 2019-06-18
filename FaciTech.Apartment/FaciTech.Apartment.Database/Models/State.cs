using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FaciTech.Apartment.Database.Models
{
    public class State
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
        [Required]
        public Guid CountryId { get; set; }
        [Required]
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
