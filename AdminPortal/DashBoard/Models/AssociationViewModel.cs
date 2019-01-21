using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Models
{
    public class AssociationViewModel
    {
        public int Id { get; set; }
        public string President { get; set; }
        [BindProperty]
        [Display(Name = "President")]
        public int PresidentId { get; set; }
        [BindProperty]
        [Display(Name = "Secretary")]
        public int SecretaryId { get; set; }
        public string Secretary { get; set; }
        public List<string> Treasurers { get; set; }
        public List<string> Members { get; set; }
        public int CommunityId { get; set; }
    }
}