using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

            modelBuilder.Types<Entity>().Configure(x => x.Property(p => p.Modified).HasColumnType("datetime2").IsConcurrencyToken());

        }


        public override int SaveChanges()
        {
            DateTime now = DateTime.Now;

            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                ((Entity)item.Entity).Modified = now;
            }

            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                ((Entity)item.Entity).Modified = now;
                ((Entity)item.Entity).Created = now;

            }

            foreach (var item in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted))
            {
                ((Entity)item.Entity).IsDeleted = true;
                item.State = EntityState.Modified;
            }

            try
            {

                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var myEx = new MyConcurrencyException();

                myEx.UserWins = () =>
                {
                    foreach (var item in ex.Entries)
                    {
                        item.OriginalValues.SetValues(item.GetDatabaseValues());
                    }
                    SaveChanges();
                };

                myEx.DbWins = () => 
                {
                    foreach (var item in ex.Entries)
                    {
                        item.CurrentValues.SetValues(item.GetDatabaseValues());
                    }
                };

                throw myEx;
            }
        }
    }
}
