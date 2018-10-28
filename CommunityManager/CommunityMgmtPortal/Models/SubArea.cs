using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class SubArea
    {
        public SubArea()
        {
            Community = new HashSet<Community>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
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
