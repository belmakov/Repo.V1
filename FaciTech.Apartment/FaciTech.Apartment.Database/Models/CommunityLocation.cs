
namespace FaciTech.Apartment.Database.Models
{
    public class CommunityLocation
    {
        public string Community { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; }
        public int AreaId { get; set; }
        public string SubArea { get; set; }
        public int SubAreaId { get; set; }
    }
}
