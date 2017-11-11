using System.Collections.Generic;

namespace FactsDatabase.Entities
{
    public class Community
    {
        public int Id { get; set; } //TODO: Create a composite Id
        public string Name { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Amenety> Ameneties { get; set; }
        public List<AmcItem> AmcItems { get; set; }
        public List<Vendor> Vendors { get; set; }
        public Association Association { get; set; }
        public object ParkingLayout { get; set; }
        /// <summary>
        /// Id, photo, contact details
        /// </summary>
        public List<GateKeeper> Gatekeeping { get; set; }
        public object Documents { get; set; }
    }
}