using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Interfaces
{
    public interface IBaseApplication<T> where T : class
    {
        Task<ActionResult<T>> GetById(Guid id);
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> Add(T entity);
        Task Remove(Guid id);
        Task<ActionResult<T>> Update(T entity);
    }
}
