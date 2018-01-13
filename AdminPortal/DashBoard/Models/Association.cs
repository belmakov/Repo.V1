using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Association
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Member> AssociationMembers { get; set; }
        public Member President { get; set; }
        public Member Secretary { get; set; }
        public List<Member> Treasurers { get; set; }
        [ForeignKey("CommunityForeignKey")]
        public Community Community { get; set; }
    }
}