using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Area : BaseEntity
    {
        public Area()
        {
            SubArea = new HashSet<SubArea>();
        }

        public string Name { get; set; }
        public Guid SupervisorId { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
        public User CreatedByNavigation { get; set; }
        public User Supervisor { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<SubArea> SubArea { get; set; }
    }
}
