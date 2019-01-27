using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Models
{
    public class BlockViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should be less than 10 characters.")]
        [MaxLength(10)]
        public string Name { get; set; }
        public List<Apartment> Flats { get; set; }
        public Community Community { get; set; }
        [BindProperty]
        public int CommunityId { get; set; }
    }
}