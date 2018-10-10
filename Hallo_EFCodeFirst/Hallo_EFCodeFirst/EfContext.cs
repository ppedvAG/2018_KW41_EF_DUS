using Hallo_EFCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hallo_EFCodeFirst
{
    public class EfContext : DbContext
    {
        public DbSet<Tier> Tiere { get; set; }
        public DbSet<Mahlzeit> Mahlzeiten { get; set; }
    }
}
