namespace FaciTech.Apartment.Database.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; } 
        //Refactor to refer Country
    }
}
