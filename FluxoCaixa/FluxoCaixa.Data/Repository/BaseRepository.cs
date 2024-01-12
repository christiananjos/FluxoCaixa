using FluxoCaixa.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Context.Set<T>();

        }

        public async Task<T> Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                await _unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //_unitOfWork.Dispose();
            }

        }

        public async Task Delete(T entity)
        {
            try
            {
                var data = await dbSet.FindAsync(entity);
                if (data != null)
                {
                    dbSet.Remove(data);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // _unitOfWork.Dispose();
            }



        }

        public async Task<T> Update(T entity)
        {
            try
            {
                dbSet.Update(entity);
                await _unitOfWork.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            finally
            {
                //_unitOfWork.Dispose();
            }

        }

        public async Task<T> GetById(Guid id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await dbSet.ToListAsync();

       


    }
}
