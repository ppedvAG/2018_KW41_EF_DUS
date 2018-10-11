using System.Collections.Generic;

namespace ppedv.ElenasUwe.Model
{
    public class Produkt : Entity
    {
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public virtual HashSet<Zubereitung> Zubereitungen { get; set; } = new HashSet<Zubereitung>();
    }
}
