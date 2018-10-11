using ppedv.ElenasUwe.Data.EF;
using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ElenasUwe.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            this.Repository = repo;
        }

        public Core() : this(new EfRepository())
        { }


        public Produkt GetSchnellstesHerzustellendesProdukt()
        {
            return Repository.Query<Produkt>().OrderBy(x => x.Zubereitungen.Sum(y => y.Vorgaenge.Sum(z => z.Zeit.Ticks))).FirstOrDefault();
        }

        public void CreateDemoDaten()
        {
            foreach (var p in GetDemoProdukte())
            {
                Repository.Add(p);
            }

            Repository.Save();
        }

        public IEnumerable<Produkt> GetDemoProdukte()
        {
            var s1 = new Stoff() { Aggregatzustand = Aggregatzustand.Fest, Name = "Stoff" };
            var s2 = new Stoff() { Aggregatzustand = Aggregatzustand.Flüssig, Name = "Alt" };
            var s3 = new Stoff() { Aggregatzustand = Aggregatzustand.Gas, Name = "Gas" };
            var s4 = new Stoff() { Aggregatzustand = Aggregatzustand.Plasma, Name = "Lasange" };

            var zub1 = new Zubereitung() { Name = "Stofflasange" };
            var z1v1 = new Vorgang() { Aktion = "In fetzten reißen", Zeit = TimeSpan.FromMinutes(7) };
            z1v1.Stoffe.Add(s1);
            var z1v2 = new Vorgang() { Aktion = "Reinschichten", Zeit = TimeSpan.FromMinutes(5) };
            z1v2.Stoffe.Add(s4);
            zub1.Vorgaenge.Add(z1v1);
            zub1.Vorgaenge.Add(z1v2);

            var p1 = new Produkt() { Name = "Caneloni", Preis = 8.90m };
            p1.Zubereitungen.Add(zub1);

            var zub2 = new Zubereitung() { Name = "Altgas" };
            var z2v1 = new Vorgang() { Aktion = "1 für mich, 1 für dich", Zeit = TimeSpan.FromMinutes(9) };
            z2v1.Stoffe.Add(s2);
            z2v1.Stoffe.Add(s3);
            zub1.Vorgaenge.Add(z2v1);

            var p2 = new Produkt() { Name = "Edelgas", Preis = 945.8m };
            p2.Zubereitungen.Add(zub2);


            var p3 = new Produkt() { Name = "Wundertüte", Preis = 0.67m };
            p3.Zubereitungen.Add(zub1);
            p3.Zubereitungen.Add(zub2);

            yield return p1;
            yield return p2;
            yield return p3;

        }
    }
}
