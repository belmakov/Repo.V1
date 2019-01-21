using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashBoard.Models
{
    public class ApartMentViewModel
    {
        public int ApartMentId { get; set; }
        [Required(ErrorMessage = "Number should be less than 10 characters.")]
        [MaxLength(10)]
        public string Number { get; set; }
        public List<Member> Members { get; set; }
        [BindProperty]
        public bool IsRented { get; set; }
        //public List<ParkingSlot> ParkingSlots { get; set; }
        //public List<Vehicle> Vehicles { get; set; }
        //public List<PersonalHelper> Helpers { get; set; }
        //public List<PersonalHelper> Drivers { get; set; }
        //public List<PersonalHelper> Cooks { get; set; }
        //public List<PersonalHelper> BabySitters { get; set; }
        public Block Block { get; set; }
        [BindProperty]
        [Display(Name = "Block")]
        public int BlockId { get; set; }
        [BindProperty]
        public int CommunityId { get; set; }
        public string BlockName { get; set; }
        public IEnumerable<SelectListItem> BlockNames { get; set; }
    }
}