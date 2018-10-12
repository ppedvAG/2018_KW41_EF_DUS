using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Contracts;

namespace ppedv.ElenasUwe.Data.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext context = new EfContext();

        public EfUnitOfWork()
        {
            pRepo = new EfProduktRepository(context);
        }

        EfProduktRepository pRepo;
        public IProduktRepository ProduktRepository => pRepo;

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new EfRepository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
