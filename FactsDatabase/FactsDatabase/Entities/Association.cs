using System.Collections.Generic;

namespace FactsDatabase.Entities
{
    public class Association
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public Member President { get; set; }
        public Member Secretary { get; set; }
        public List<Member> Treasurers { get; set; }
    }
}