namespace FaciTech.Apartment.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        Contact Contact { get; set; }
    }
}
