using ppedv.ElenasUwe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public EfContext() : this("Server=.;Database=EleneasUwe;Trusted_Connection=true")
        { }

        public EfContext(string nameConString) : base(nameConString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Zubereitung>().HasMany(x => x.Vorgaenge)
                                              .WithRequired(x => x.Zubereitung)
                                              .WillCascadeOnDelete(true);
        }
    }
}
