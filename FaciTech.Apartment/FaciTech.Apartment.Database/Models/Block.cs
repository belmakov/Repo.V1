
using System.ComponentModel.DataAnnotations.Schema;

namespace FaciTech.Apartment.Database.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string BlockName {get;set;}
        public int NoOfFloors { get; set; }
        public int CommunityId { get; set; }
        [ForeignKey("CommunityId")]
        public Community Community { get; set; }
    }
}
