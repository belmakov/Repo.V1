using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class PersonalHelper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public Address ContactDetails { get; set; }
        //public Apartment Apartment { get; set; }
        public string Role { get; set; }
    }
}