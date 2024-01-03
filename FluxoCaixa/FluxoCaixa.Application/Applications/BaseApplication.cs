using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;

namespace FluxoCaixa.Application.Applications
{
    public abstract class BaseApplication<T> : IBaseApplication<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        IBaseRepository<T> _repository;

        protected BaseApplication(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<T> Add(T entity)
        {
            return await _repository.Add(entity);
        }

        public async Task Remove(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
    }
}
