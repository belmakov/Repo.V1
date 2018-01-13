using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Community
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Amenety> Ameneties { get; set; }
        public List<AmcItem> AmcItems { get; set; }
        public List<Vendor> Vendors { get; set; }
        public Association Association { get; set; }
        public ParkingLayout ParkingLayout { get; set; }
        /// <summary>
        /// Id, photo, contact details
        /// </summary>
        public List<GateKeeper> Gatekeeping { get; set; }
        //public object Documents { get; set; }
        [ForeignKey("SectionForeignKey")]
        public Section Section { get; set; }
    }
}