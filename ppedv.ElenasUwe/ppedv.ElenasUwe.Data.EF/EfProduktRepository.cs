using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ElenasUwe.Data.EF
{
    public class EfProduktRepository : EfRepository<Produkt>, IProduktRepository
    {
        public EfProduktRepository(EfContext context) : base(context)
        { }
        public IEnumerable<Produkt> GetGrünsteProdukte()
        {
            return context.Produkte.Where(x => x.Name.StartsWith("green"));
        }
    }
}
