using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Models
{
    public class SectionViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name should be less than 10 characters.")]
        [MaxLength(10)]
        public string Name { get; set; }
        public List<Unit> Flats { get; set; }
        public Community Community { get; set; }
        [BindProperty]
        public Guid CommunityId { get; set; }
    }
}