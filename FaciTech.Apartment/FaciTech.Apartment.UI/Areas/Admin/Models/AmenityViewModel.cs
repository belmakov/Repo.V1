namespace FaciTech.Apartment.UI.Areas.Admin.Models
{
    public class AmenityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public AmenityViewModel()
        {
            Selected = false;
        }
    }
}