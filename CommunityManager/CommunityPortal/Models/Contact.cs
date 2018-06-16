﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityPortal.Models
{
    public class Contact
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Guid LocationID { get; set; }
    }
}
