using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class RegionType : BaseEntity
    {
        public RegionType()
        {
            Region = new HashSet<Region>();
        }

        public string Name { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Region> Region { get; set; }
    }
}
