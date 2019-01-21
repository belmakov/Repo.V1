using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class SubAreaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage ="Name should be less than 50 characters.")]
        public string Name { get; set; }
        public string Area { get; set; }
        [BindProperty]
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }
    }
}