using System.Collections.Generic;

namespace ppedv.ElenasUwe.Model
{
    public class Stoff : Entity
    {
        public string Name { get; set; }
        public Aggregatzustand Aggregatzustand { get; set; }
        public virtual HashSet<Vorgang> Vorgaenge { get; set; } = new HashSet<Vorgang>();
    }
}
