using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class RegionViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(4, ErrorMessage = "Minimum length is 10.")]
        [MaxLength(80, ErrorMessage = "Maximum length is 80")]
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
