using System.Collections.Generic;
using System.Linq;

namespace ppedv.ElenasUwe.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Query();
        T GetById(int id);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
