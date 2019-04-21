using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public String Comments { get; set; }
        public Boolean Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
        [Required(ErrorMessage = "Number should be less than 50 characters.")]
        [MaxLength(50)]
        public string Number { get; set; }
        public Contact Owner { get; set; }
        public List<Contact> Tenants { get; set; }
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