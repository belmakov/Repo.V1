using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Number should be less than 10 characters.")]
        [MaxLength(10)]
        public string Number { get; set; }
        public List<Member> Members { get; set; }
        public bool IsRented { get; set; }
        //public List<ParkingSlot> ParkingSlots { get; set; }
        //public List<Vehicle> Vehicles { get; set; }
        //public List<PersonalHelper> Helpers { get; set; }
        //public List<PersonalHelper> Drivers { get; set; }
        //public List<PersonalHelper> Cooks { get; set; }
        //public List<PersonalHelper> BabySitters { get; set; }
        public Block Block { get; set; }
    }
}