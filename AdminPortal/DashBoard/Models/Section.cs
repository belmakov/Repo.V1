using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Section
    {
        [Required(ErrorMessage = "Zone is required.")]
        public Zone Zone { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("RegionForeignKey")]
        public Region Region { get; set; }
        public ICollection<Community> Communities { get; set; } = new List<Community>();
    }
}