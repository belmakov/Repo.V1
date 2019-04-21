using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class Member
    {
        [Key]
        public Guid Id { get; set; }
        public String Comments { get; set; }
        public Boolean Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime Updated { get; set; }

        public Contact Person { get; set; }

        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsAssociationMember { get; set; }
        public Apartment Apartment { get; set; }
    }

    public class MemberCollectionViewModel
    {
        public IEnumerable<MemberViewModel> MemberInfos { get; set; }
        public Guid ApartmentId { get; set; }
    }

    public class MemberViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public bool IsAssociationMember { get; set; }
        public Guid ApartmentId { get; set; }
    }
}