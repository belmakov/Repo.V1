
using System;

namespace FaciTech.Apartment.Database.Models
{
    public class CommunityLocation
    {
        public string Community { get; set; }
        public Guid Id { get; set; }
        public string Country { get; set; }
        public Guid CountryId { get; set; }
        public string City { get; set; }
        public Guid CityId { get; set; }
        public string Area { get; set; }
        public Guid AreaId { get; set; }
        public string SubArea { get; set; }
        public Guid SubAreaId { get; set; }
    }
}
