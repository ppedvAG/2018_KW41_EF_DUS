using System.Collections.Generic;

namespace Hallo_EFCodeFirst.Model
{
    public class Mahlzeit : Entity
    {
        public string Bezeichnung { get; set; }
        public HashSet<Tier> Tiere { get; set; } = new HashSet<Tier>();
    }
}
