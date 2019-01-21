using System.Collections.Generic;

namespace DashBoard.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
