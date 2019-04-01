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
        public string Purpose { get; set; }
        public DateTime Schedule { get; set; }
        public Location Address { get; set; }
        //public Community Community { get; set; }
    }
}