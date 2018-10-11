using AutoFixture;
using FluentAssertions;
using ppedv.ElenasUwe.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.ElenasUwe.Data.EF.Tests
{
    public class EfContextTests
    {
        string testConString = "Server=.;Database=EleneasUwe_dev;Trusted_Connection=true";

        public EfContextTests()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
        }

        [Fact]
        public void Can_create_database()
        {
            var con = new EfContext(testConString);

            if (con.Database.Exists())
                con.Database.Delete();

            con.Database.Create();

            Assert.True(con.Database.Exists());
        }

        [Fact]
        public void Can_CRUD_Produkt()
        {
            var prod = new Produkt() { Name = $"Altbier_{Guid.NewGuid()}", Preis = 3.2m };
            string newName = $"HellesAlt_{Guid.NewGuid()}";

            using (var con = new EfContext(testConString))
            {
                //CREATE
                con.Produkte.Add(prod);
                con.SaveChanges();
            }

            using (var con = new EfContext(testConString))
            {
                //READ
                var loaded = con.Produkte.Find(prod.Id);
                Assert.NotNull(loaded);
                Assert.Equal(prod.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext(testConString))
            {
                var loaded = con.Produkte.Find(prod.Id);
                Assert.Equal(newName, loaded.Name);

                //DELETE
                con.Produkte.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext(testConString))
            {
                var loaded = con.Produkte.Find(prod.Id);
                Assert.Null(loaded);
            }
        }

        [Fact]
        public void Can_CR_Produkt_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var prod = fix.Build<Produkt>().Without(x => x.Created).Without(x => x.Modified).Create();


            //Create
            using (var con = new EfContext(testConString))
            {
                con.Produkte.Add(prod);
                con.SaveChanges();
            }

            //Read
            using (var con = new EfContext(testConString))
            {
                var loaded = con.Produkte.Find(prod.Id);

                loaded.Should().BeEquivalentTo(prod, o =>
                {
                    o.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation)).WhenTypeIs<DateTime>();
                    o.IgnoringCyclicReferences();
                    return o;
                });

                ////UPDATE
                //var updated = fix.Build<Produkt>().Without(x => x.Created).Without(x => x.Modified).Create();
                //updated.Id = loaded.Id;
                //con.Entry(loaded).State = System.Data.Entity.EntityState.Detached;

                //con.Produkte.Attach(updated);
                ////con.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                //con.SaveChanges();
            }
        }

        [Fact]
        public void Delete_cascades_Zubereitung_Vorgang()
        {
            var v1 = new Vorgang() { Aktion = "A1", Zeit = TimeSpan.FromMinutes(3) };
            var v2 = new Vorgang() { Aktion = "A2", Zeit = TimeSpan.FromMinutes(5) };

            var z = new Zubereitung() { Name = "Testsuppe" };

            z.Vorgaenge.Add(v1);
            z.Vorgaenge.Add(v2);

            using (var con = new EfContext(testConString))
            {
                con.Zubereitungen.Add(z);
                con.SaveChanges();
            }


            using (var con = new EfContext(testConString))
            {
                var loaded = con.Zubereitungen.Find(z.Id);
                loaded.Vorgaenge.Count.Should().Be(2); //insert cascade

                //delete v2
                var v2_loaded = loaded.Vorgaenge.FirstOrDefault(x => x.Aktion == "A2");
                con.Vorgaenge.Remove(v2_loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext(testConString))
            {
                var loaded = con.Zubereitungen.Find(z.Id);
                loaded.Should().NotBeNull("Vorgang hat Zubereitung gelöscht :-(");
                loaded.Vorgaenge.Count.Should().Be(1);

                //delete zub
                con.Zubereitungen.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext(testConString))
            {
                con.Zubereitungen.Find(z.Id).Should().BeNull();
                con.Vorgaenge.Find(v1.Id).Should().BeNull("Zubereitung hat NICHT den Vorgang gelöscht :-(");
            }

        }

    }

}
