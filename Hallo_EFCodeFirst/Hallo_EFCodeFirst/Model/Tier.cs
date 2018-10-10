using System.Collections.Generic;

namespace Hallo_EFCodeFirst.Model
{
    public class Tier : Entity
    {
        public string Art { get; set; }
        public int AnzahlBeine { get; set; }
        public Tieroberfläche Oberfläche { get; set; }
        public HashSet<Mahlzeit> Mahlzeiten { get; set; } = new HashSet<Mahlzeit>();

    }
}
