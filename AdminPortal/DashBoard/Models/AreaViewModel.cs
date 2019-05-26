﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DashBoard.Models
{
    public class AreaViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(4, ErrorMessage = "Minimum length is 10.")]
        [MaxLength(80, ErrorMessage = "Maximum length is 80")]
        public string Name { get; set; }
        [Display(Name = "City")]
        [BindProperty]
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
