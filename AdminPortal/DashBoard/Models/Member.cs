using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }

        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public bool IsAssociationMember { get; set; }
        public Apartment Apartment { get; set; }
    }

    public class MemberCollectionViewModel
    {
        public IEnumerable<MemberViewModel> MemberInfos { get; set; }
        public int ApartmentId { get; set; }
    }

    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public bool IsAssociationMember { get; set; }
        public int ApartmentId { get; set; }
    }
}