using ppedv.ElenasUwe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ElenasUwe.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Stoff> Stoffe { get; set; }
        public DbSet<Zubereitung> Zubereitungen { get; set; }
        public DbSet<Vorgang> Vorgaenge { get; set; }
        public DbSet<Produkt> Produkte { get; set; }

        public EfContext() : this("Server=.;Database=EleneasUwe;Trusted_Connections=true")
        { }

        public EfContext(string nameConString) : base(nameConString)
        { }
    }
}
