using System.Collections.Generic;

namespace DashBoard.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }    
        public City City { get; set; }
        public ICollection<SubArea> SubAreas { get; set; }
    }
}
