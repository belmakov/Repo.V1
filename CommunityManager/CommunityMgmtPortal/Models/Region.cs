using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Region
    {
        public Region()
        {
            City = new HashSet<City>();
            Location = new HashSet<Location>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
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
