namespace ppedv.ElenasUwe.Model.Contracts
{
    public interface IUnitOfWork
    {
        IProduktRepository ProduktRepository { get; }
        IRepository<T> GetRepository<T>() where T : Entity;

        void Save();
    }
}
