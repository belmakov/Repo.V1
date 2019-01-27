using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Region : BaseEntity
    {
        public Region()
        {
            City = new HashSet<City>();
            Location = new HashSet<Location>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Timezone { get; set; }
        public Guid RegionTypeId { get; set; }
        public Guid CountryId { get; set; }

        public Country Country { get; set; }
        public User CreatedByNavigation { get; set; }
        public RegionType RegionType { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<Location> Location { get; set; }
    }
}
