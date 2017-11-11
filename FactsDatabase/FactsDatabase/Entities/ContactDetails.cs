using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactsDatabase.Entities
{
    public class ContactDetails
    {
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string HouseOrFlatNumber { get; set; }
        public string ApartmentName { get; set; }
        public string Street { get; set; }
        public string LocationOrArea { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
    }
}
