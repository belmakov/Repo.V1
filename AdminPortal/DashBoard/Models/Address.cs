using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //TODO: Create a composite Id
        public string ApartmentName { get; set; }
        public string Street { get; set; }
        public string LocationOrArea { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        [ForeignKey("PersonalHelperForeignKey")]
        public PersonalHelper PersonalHelper { get; set; }
        [ForeignKey("GateKeeperForeignKey")]
        public GateKeeper GateKeeper { get; set; }
        [ForeignKey("VendorForeignKey")]
        public Vendor Vendor { get; set; }

    }
}