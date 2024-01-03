namespace FluxoCaixa.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task Delete(Guid entity);
        Task Update(T entity);
    }
}
