using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    public class Unit
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }

        public Guid TenantID { get; set; }
        public Guid OwnerID { get; set; }
    }
}
