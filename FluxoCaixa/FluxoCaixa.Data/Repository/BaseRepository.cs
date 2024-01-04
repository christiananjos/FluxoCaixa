using FluxoCaixa.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly FluxoContext _dbContext;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Context.Set<T>();

        }

        public async Task<T> GetById(Guid id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            dbSet.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            var data = await dbSet.FindAsync(id);
            if (data != null)
            {
                dbSet.Remove(data);
                await _unitOfWork.SaveChangesAsync();
            }


        }

        public async Task<T> Update(T entity)
        {
            var data = await dbSet.FindAsync(entity);

            _unitOfWork.Context.Entry(data).CurrentValues.SetValues(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }


    }
}
