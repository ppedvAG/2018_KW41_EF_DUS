using Hallo_EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallo_EFCodeFirst
{
    public class EfContext : DbContext
    {
        public DbSet<Tier> Tiere { get; set; }
        public DbSet<Mahlzeit> Mahlzeiten { get; set; }

       // public EfContext() : base("Server=.;Database=Mahlzeiten;Trusted_Connection=true")
        public EfContext() : base("name=MyConString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Tier>().ToTable("SourceAnimal");
            modelBuilder.Entity<Tier>().Property(x => x.AnzahlBeine).HasColumnName("LegCount").HasColumnType("tinyint").IsOptional();


        }
    }
}
