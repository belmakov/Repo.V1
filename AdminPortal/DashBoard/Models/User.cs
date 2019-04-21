using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public String Comments { get; set; }
        public Boolean Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime Updated { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Contact UserContact { get; set; }
    }
}
