using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityMgmtPortal.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Boolean Active { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public String Comments { get; set; }
        public String Tags { get; set; }
    }
}
