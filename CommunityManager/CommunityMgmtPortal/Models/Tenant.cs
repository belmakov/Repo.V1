using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            TenantAmenityEntitlement = new HashSet<TenantAmenityEntitlement>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public bool Primary { get; set; }
        public Guid ContactId { get; set; }
        public Guid UnitId { get; set; }

        public Contact Contact { get; set; }
        public User CreatedByNavigation { get; set; }
        public Unit Unit { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<TenantAmenityEntitlement> TenantAmenityEntitlement { get; set; }
    }
}
