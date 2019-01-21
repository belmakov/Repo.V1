using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public string Number { get; set; }
        //public Apartment Apartment { get; set; }
    }
}