using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Community
    {
        public Community()
        {
            Block = new HashSet<Block>();
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
        public Guid LocationId { get; set; }
        public Guid SubAreaId { get; set; }

        public User CreatedByNavigation { get; set; }
        public Location Location { get; set; }
        public SubArea SubArea { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Block> Block { get; set; }
    }
}
