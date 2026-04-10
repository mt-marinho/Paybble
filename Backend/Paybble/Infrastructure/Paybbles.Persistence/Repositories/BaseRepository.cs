using Microsoft.EntityFrameworkCore;
using Paybble.Application.Contracts.Persistence;

namespace Paybble.Persistence.Repositories
{
    public class BaseRepository<T>(PaybbleDbComtext dbcontext) : IAsyncRepository<T> where T : class
    {
        public async Task<T> GetByIdAsync(int id)
        {
            return await dbcontext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbcontext.Set<T>().AddAsync(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbcontext.Set<T>().Update(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            dbcontext.Set<T>().Remove(entity);
            await dbcontext.SaveChangesAsync();
            return entity;
        }
    }
}
