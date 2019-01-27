using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Amenity : BaseEntity
    {
        public Amenity()
        {
            TenantAmenityEntitlement = new HashSet<TenantAmenityEntitlement>();
        }

        public string Name { get; set; }
        public Guid AmenityTypeId { get; set; }
        public string Description { get; set; }

        public AmenityType AmenityType { get; set; }
        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<TenantAmenityEntitlement> TenantAmenityEntitlement { get; set; }
    }
}
