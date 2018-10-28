using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Tenant = new HashSet<Tenant>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
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
