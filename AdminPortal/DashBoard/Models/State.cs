using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashBoard.Models
{
    public class State
    {
        public string Country { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
