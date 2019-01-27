using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Block : BaseEntity
    {
        public Block()
        {
            Unit = new HashSet<Unit>();
        }

        public Guid CommunityId { get; set; }
        public string Name { get; set; }

        public Community Community { get; set; }
        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Unit> Unit { get; set; }
    }
}
