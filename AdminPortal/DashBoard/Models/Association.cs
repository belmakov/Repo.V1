using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Association
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public List<Member> Members { get; set; }
        public Member President { get; set; }
        public Member Secretary { get; set; }
        public List<Member> Treasurers { get; set; }
        public Community Community { get; set; }
    }
}