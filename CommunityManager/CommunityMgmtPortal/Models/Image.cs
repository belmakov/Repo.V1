using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Image
    {
        public Image()
        {
            Contact = new HashSet<Contact>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public byte[] Image1 { get; set; }

        public ICollection<Contact> Contact { get; set; }
    }
}
