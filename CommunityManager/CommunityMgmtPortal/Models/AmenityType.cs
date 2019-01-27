using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class AmenityType : BaseEntity
    {
        public AmenityType()
        {
            Amenity = new HashSet<Amenity>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Amenity> Amenity { get; set; }
    }
}
