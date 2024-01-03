namespace FluxoCaixa.Application.Interfaces
{
    public interface IBaseApplication<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task Remove(Guid id);
        Task Update(T entity);
    }
}
