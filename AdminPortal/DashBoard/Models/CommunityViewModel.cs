using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class CommunityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name should be less than 50 characters.")]
        public string Name { get; set; }
        public string SubArea { get; set; }
        [BindProperty]
        [Display(Name = "SubArea")]
        public int SubAreaId { get; set; }
        public IEnumerable<SelectListItem> SubAreas { get; set; }
        public string AreaName { get; set; } 
        public AssociationViewModel Association { get; set; }
        public IEnumerable<BlockViewModel> Blocks { get; set; }
    }
}