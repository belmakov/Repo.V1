
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FaciTech.Apartment.Database.Models
{
    public class Community
    {
        [Required]
        public Guid Id { get; set; }
        public String Comments { get; set; }
        [Required]
        public Boolean Inactive { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public Guid UpdatedBy { get; set; }
        [Required]
        public DateTime Updated { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String BuilderName { get; set; }
        public String Address { get; set; }
        public String Landmark { get; set; }
        public String LocationLink { get; set; }
        public String AssociationName { get; set; }
        public String AssociationNumber { get; set; }
        public String AssociationBankName { get; set; }
        public String AssociationBankAccountNumber { get; set; }
        public String AssociationBankBranchAddress { get; set; }
        public String AssociationBankIFSC { get; set; }
        public String AmenityIds { get; set; }

        [Required]
        public Guid SubAreaId { get; set; }
        [Required]
        public SubArea SubArea { get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
