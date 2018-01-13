using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Block
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should be less than 10 characters.")]
        [MaxLength(10)]
        public string Name { get; set; }

        public List<Flat> Flats { get; set; }
        [ForeignKey("CommunityForeignKey")]
        public Community Community { get; set; }
    }
}