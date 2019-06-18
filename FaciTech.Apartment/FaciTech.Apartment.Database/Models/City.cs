using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaciTech.Apartment.Database.Models
{
    public class City
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
        public Guid StateId { get; set; }
        [Required]
        public State State { get; set; }
        //Refactor to refer Country

        public ICollection<Area> Areas { get; set; }
    }
}
