using System.ComponentModel.DataAnnotations.Schema;

namespace FaciTech.Apartment.Database.Models
{
    public class Unit
    {
        public int Id { get; set; }       
        public int BlockId { get; set; }
        [ForeignKey("BlockId")]
        public Block Block { get; set; }
        public int FloorNumber { get; set; }
        public string UnitNumber { get; set; }
        public string Specification { get; set; }

    }
}