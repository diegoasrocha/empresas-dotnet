using ManageEnterprises.Infrastructure.DBConfiguration.EFCore;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace ManageEnterprises.Infrastructure.Repositories
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryAsync(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var res = await dbSet.AddAsync(obj);
            await SaveAsync();

            return res.Entity;
        }

        public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);

            return await SaveAsync();
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(dbSet);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> RemoveAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);

            if (entity == null) return false;

            return await RemoveAsync(entity) > 0;
        }

        public virtual async Task<int> RemoveAsync(TEntity obj)
        {
            dbSet.Remove(obj);

            return await SaveAsync();
        }

        public virtual async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);

            return await SaveAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity obj)
        {
            dbSet.Update(obj);

            return await SaveAsync();
        }

        public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);

            return await SaveAsync();
        }

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
    }
}
