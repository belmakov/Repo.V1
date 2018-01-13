using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Vendor : ExternalMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        public string Pupose { get; set; }
        public DateTime Schedule { get; set; }
        public Address Address { get; set; }
        [ForeignKey("CommunityForeignKey")]
        public Community Community { get; set; }
    }
}