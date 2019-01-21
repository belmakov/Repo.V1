using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class ParkingLayout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public List<ParkingSlot> ParkingSlots { get; set; }
        //public Community Community { get; set; }
    }
}