namespace FluxoCaixa.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();

    }
}
