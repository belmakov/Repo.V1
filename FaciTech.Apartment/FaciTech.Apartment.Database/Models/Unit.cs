using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaciTech.Apartment.Database.Models
{
    public class Unit
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
        public Guid SectionId { get; set; }
        [ForeignKey("BlockId")]
        public Section Section { get; set; }
        public int FloorNumber { get; set; }
        [Required]
        public String Number { get; set; }
        public String Specification { get; set; }

    }
}