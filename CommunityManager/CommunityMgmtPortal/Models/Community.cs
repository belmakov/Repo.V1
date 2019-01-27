using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Community : BaseEntity
    {
        public Community()
        {
            Block = new HashSet<Block>();
        }

        public string Name { get; set; }
        public Guid LocationId { get; set; }
        public Guid SubAreaId { get; set; }

        public User CreatedByNavigation { get; set; }
        public Location Location { get; set; }
        public SubArea SubArea { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Block> Block { get; set; }
    }
}
