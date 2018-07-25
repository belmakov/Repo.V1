using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    public class Apartment
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int CommunityID { get; set; }
        public Guid LocationID { get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
