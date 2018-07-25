using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    public class Community
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
