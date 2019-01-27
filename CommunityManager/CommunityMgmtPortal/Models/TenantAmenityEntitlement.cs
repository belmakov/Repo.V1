using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class TenantAmenityEntitlement : BaseEntity
    {

        public Guid TenantId { get; set; }
        public Guid AmenityId { get; set; }

        public Amenity Amenity { get; set; }
        public User CreatedByNavigation { get; set; }
        public Tenant Tenant { get; set; }
        public User UpdatedByNavigation { get; set; }
    }
}
