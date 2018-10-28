using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityMgmtPortal.Models
{
    public class Community : BaseEntity
    {
        public String Name { get; set; }
        public Guid LocationId { get; set; }
        public Guid SubAreaId { get; set; }
    }
}
