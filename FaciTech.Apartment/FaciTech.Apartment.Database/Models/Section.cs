
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaciTech.Apartment.Database.Models
{
    public class Section
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
        public string Name {get;set;}
        public int NoOfFloors { get; set; }
        public Guid CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public Community Community { get; set; }
    }
}
