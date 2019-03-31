using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class SubArea
    {
        [Key]
        public int SubAreaId { get; set; }
        public string SubAreaName { get; set; }
        public Area Area { get; set; }
        public ICollection<Community> Communities { get; set; }
    }
}
