using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Tenant : BaseEntity
    {
        public Tenant()
        {
            TenantAmenityEntitlement = new HashSet<TenantAmenityEntitlement>();
        }

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
