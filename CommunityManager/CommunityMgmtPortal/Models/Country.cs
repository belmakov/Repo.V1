using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Country
    {
        public Country()
        {
            Location = new HashSet<Location>();
            Region = new HashSet<Region>();
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
        public string CurrencyCode { get; set; }
        public string Timezone { get; set; }
        public int? TelephoneCode { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Location> Location { get; set; }
        public ICollection<Region> Region { get; set; }
    }
}
