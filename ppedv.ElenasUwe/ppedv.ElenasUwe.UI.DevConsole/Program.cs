using ppedv.ElenasUwe.Logic;
using ppedv.ElenasUwe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ElenasUwe.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("*** Elenas Uwe (el Uwos) 🎂 🎃🎁🎀📱 ***");

            var core = new Core();

            if (core.Repository.Query<Produkt>().Count() == 0)
                core.CreateDemoDaten();
                
            foreach (var prod in core.Repository.GetAll<Produkt>())
            {
                Console.WriteLine($"{prod.Name} {prod.Preis:c}");
                foreach (var zub in prod.Zubereitungen)
                {
                    Console.WriteLine($"\t{zub.Name}");
                    foreach (var vrg in zub.Vorgaenge)
                    {
                        Console.WriteLine($"\t\t{string.Join(", ", vrg.Stoffe.Select(x => x.Name))} {vrg.Zeit.TotalSeconds}s {vrg.Aktion}");
                    }
                }
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
