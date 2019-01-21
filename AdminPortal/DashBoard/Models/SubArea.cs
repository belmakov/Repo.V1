using System.Collections.Generic;

namespace DashBoard.Models
{
    public class SubArea
    {
        public int SubAreaId { get; set; }
        public string SubAreaName { get; set; }
        public Area Area { get; set; }
        public ICollection<Community> Communities { get; set; }
    }
}
