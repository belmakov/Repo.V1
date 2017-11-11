using System.Collections.Generic;

namespace FactsDatabase.Entities
{
    public class Flat
    {
        public string Number { get; set; }
        public int BlockId { get; set; }
        public List<Member> Members { get; set; }
        public bool IsRented { get; set; }
        public List<string> ParkingSlots { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Maids { get; set; }
        public List<string> Drivers { get; set; }
        public List<string> Cooks { get; set; }
        public List<string> BabySitters { get; set; }
    }
}