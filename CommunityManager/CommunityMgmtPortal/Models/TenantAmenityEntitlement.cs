using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class TenantAmenityEntitlement
    {
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public Guid TenantId { get; set; }
        public Guid AmenityId { get; set; }

        public Amenity Amenity { get; set; }
        public User CreatedByNavigation { get; set; }
        public Tenant Tenant { get; set; }
        public User UpdatedByNavigation { get; set; }
    }
}
