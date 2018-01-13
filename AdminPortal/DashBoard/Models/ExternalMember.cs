using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class ExternalMember
    {
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}