using System;
using System.Collections.Generic;

namespace ppedv.ElenasUwe.Model
{
    public class Vorgang : Entity
    {
        public string Aktion { get; set; }
        public TimeSpan Zeit { get; set; }
        public virtual Zubereitung Zubereitung { get; set; }
        public virtual HashSet<Stoff> Stoffe { get; set; } = new HashSet<Stoff>();
    }
}
