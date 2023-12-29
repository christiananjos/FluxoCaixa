namespace FluxoCaixa.Application.Interfaces
{
    public interface IBaseApplication<T> where T : class
    {
        Task GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
