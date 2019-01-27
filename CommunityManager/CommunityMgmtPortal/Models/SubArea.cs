using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class SubArea : BaseEntity
    {
        public SubArea()
        {
            Community = new HashSet<Community>();
        }

        public Guid AreaId { get; set; }
        public Guid SupervisorId { get; set; }
        public string Name { get; set; }

        public Area Area { get; set; }
        public User CreatedByNavigation { get; set; }
        public User Supervisor { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Community> Community { get; set; }
    }
}
