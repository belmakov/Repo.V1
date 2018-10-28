using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityMgmtPortal.Models
{
    public class Area : BaseEntity
    {
        public String Name { get; set; }
        public Guid CityId { get; set; }
        public Guid SupervisorId { get; set; }
    }
}
