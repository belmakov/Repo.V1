using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }
        public string AreaName { get; set; }    
        public City City { get; set; }
        public ICollection<SubArea> SubAreas { get; set; }
    }
}
