using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    public class Section
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid ApartmentID { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
