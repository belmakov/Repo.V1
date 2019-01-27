using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class City : BaseEntity
    {
        public City()
        {
            Area = new HashSet<Area>();
            Location = new HashSet<Location>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? TelephoneCode { get; set; }
        public string Timezone { get; set; }
        public Guid RegionId { get; set; }

        public User CreatedByNavigation { get; set; }
        public Region Region { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Area> Area { get; set; }
        public ICollection<Location> Location { get; set; }
    }
}
