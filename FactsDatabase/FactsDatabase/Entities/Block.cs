using System.Collections.Generic;

namespace FactsDatabase.Entities
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Flat> Flats { get; set; }
    }
}