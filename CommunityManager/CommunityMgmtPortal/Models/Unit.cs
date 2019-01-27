using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Unit : BaseEntity
    {
        public Unit()
        {
            Tenant = new HashSet<Tenant>();
        }

        public string Identifier { get; set; }
        public Guid BlockId { get; set; }
        public Guid OwnerId { get; set; }
        public bool MaintainenceFeePaid { get; set; }

        public Block Block { get; set; }
        public User CreatedByNavigation { get; set; }
        public Contact Owner { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Tenant> Tenant { get; set; }
    }
}
