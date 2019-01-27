using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Location = new HashSet<Location>();
            Region = new HashSet<Region>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string CurrencyCode { get; set; }
        public string Timezone { get; set; }
        public int? TelephoneCode { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Location> Location { get; set; }
        public ICollection<Region> Region { get; set; }
    }
}
