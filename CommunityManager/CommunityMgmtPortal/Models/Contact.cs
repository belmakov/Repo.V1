using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Tenant = new HashSet<Tenant>();
            Unit = new HashSet<Unit>();
            User = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Active { get; set; }
        public string Tags { get; set; }
        public string Comments { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? ImageId { get; set; }

        public User CreatedByNavigation { get; set; }
        public Image Image { get; set; }
        public Location Location { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Tenant> Tenant { get; set; }
        public ICollection<Unit> Unit { get; set; }
        public ICollection<User> User { get; set; }
    }
}
