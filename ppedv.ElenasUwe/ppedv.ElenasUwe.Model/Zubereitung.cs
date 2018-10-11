using System.Collections.Generic;

namespace ppedv.ElenasUwe.Model
{
    public class Zubereitung : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Vorgang> Vorgaenge { get; set; } = new HashSet<Vorgang>();
        public virtual HashSet<Produkt> Produkte { get; set; } = new HashSet<Produkt>();

    }
}
