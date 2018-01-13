using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class GateKeeper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        //public object Photo { get; set; }
        public Address Address{ get; set; }
        [ForeignKey("CommunityForeignKey")]
        public Community Community { get; set; }
    }
}