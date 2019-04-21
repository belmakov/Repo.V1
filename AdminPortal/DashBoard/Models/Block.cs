using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class Block
    {
        public Guid Id { get; set; }
        public String Comments { get; set; }
        public Boolean Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Apartment> Apartments { get; set; }
        public Community Community { get; set; }
    }
}