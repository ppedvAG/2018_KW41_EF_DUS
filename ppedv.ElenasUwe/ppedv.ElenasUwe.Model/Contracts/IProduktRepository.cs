using System.Collections.Generic;

namespace ppedv.ElenasUwe.Model.Contracts
{
    public interface IProduktRepository : IRepository<Produkt>
    {
        IEnumerable<Produkt> GetGrünsteProdukte();
    }
}
