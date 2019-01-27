using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Image : BaseEntity
    {
        public Image()
        {
            Contact = new HashSet<Contact>();
        }

        public byte[] Image1 { get; set; }

        public ICollection<Contact> Contact { get; set; }
    }
}
