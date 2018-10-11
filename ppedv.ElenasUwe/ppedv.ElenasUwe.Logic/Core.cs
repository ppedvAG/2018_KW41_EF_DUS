using ppedv.ElenasUwe.Data.EF;
using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Contracts;
using System;

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

        public void CreateDemoDaten()
        {
            var s1 = new Stoff() { Aggregatzustand = Aggregatzustand.Fest, Name = "Stoff" };
            var s2 = new Stoff() { Aggregatzustand = Aggregatzustand.Flüssig, Name = "Alt" };
            var s3 = new Stoff() { Aggregatzustand = Aggregatzustand.Gas, Name = "Gas" };
            var s4 = new Stoff() { Aggregatzustand = Aggregatzustand.Plasma, Name = "Lasange" };

            var zub1 = new Zubereitung() { Name = "Stofflasange" };
            var z1v1 = new Vorgang() { Aktion = "In fetzten reißen" };
            z1v1.Stoffe.Add(s1);
            var z1v2 = new Vorgang() { Aktion = "Reinschichten" };
            z1v2.Stoffe.Add(s4);
            zub1.Vorgaenge.Add(z1v1);
            zub1.Vorgaenge.Add(z1v2);

            var p1 = new Produkt() { Name = "Caneloni", Preis = 8.90m };
            p1.Zubereitungen.Add(zub1);
            Repository.Add(p1);

            var zub2 = new Zubereitung() { Name = "Altgas" };
            var z2v1 = new Vorgang() { Aktion = "1 für mich, 1 für dich" };
            z2v1.Stoffe.Add(s2);
            z2v1.Stoffe.Add(s3);
            zub1.Vorgaenge.Add(z2v1);

            var p2 = new Produkt() { Name = "Edelgas", Preis = 945.8m };
            p2.Zubereitungen.Add(zub2);
            Repository.Add(p2);

            var p3 = new Produkt() { Name = "Wundertüte", Preis = 0.67m };
            p3.Zubereitungen.Add(zub1);
            p3.Zubereitungen.Add(zub2);

            Repository.Add(p3);
            Repository.Save();
        }
    }
}
