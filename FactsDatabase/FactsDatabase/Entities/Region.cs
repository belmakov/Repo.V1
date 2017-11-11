using System.Collections.Generic;

namespace FactsDatabase.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Zone> Zones { get; set; }
    }
}