using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Area
    {
        public Area()
        {
            SubArea = new HashSet<SubArea>();
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
        public Guid SupervisorId { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
        public User CreatedByNavigation { get; set; }
        public User Supervisor { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<SubArea> SubArea { get; set; }
    }
}
