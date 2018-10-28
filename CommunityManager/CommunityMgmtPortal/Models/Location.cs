using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Location
    {
        public Location()
        {
            Community = new HashSet<Community>();
            Contact = new HashSet<Contact>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LocalityName { get; set; }
        public string Landmarks { get; set; }
        public string PinCode { get; set; }
        public string MapCordinates { get; set; }
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public User CreatedByNavigation { get; set; }
        public Region Region { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Community> Community { get; set; }
        public ICollection<Contact> Contact { get; set; }
    }
}
