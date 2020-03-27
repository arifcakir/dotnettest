using Microsoft.EntityFrameworkCore;
using SMS.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Core.Data
{
    public  class BaseAsyncRepository<T> : IAsyncRepository<T> where T: BaseDataEntity, IDataEntity
    {

        private readonly DbContext _dbContext;

        public BaseAsyncRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync(); 
        }

        public async Task<T> GetById(object id)
        {
           return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAll()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<T> Insert(T obj)
        {
          var t = await  _dbContext.Set<T>().AddAsync(obj);

          return t.Entity;
        }

        public async Task Update(T obj)
        {
            var t = await _dbContext.Set<T>().FindAsync(obj.Id);
            _dbContext.Entry(t).CurrentValues.SetValues(obj);
        }

        public async Task<bool> Delete(T obj)
        {
            _dbContext.Attach(obj);
            await Task.Run(()=> _dbContext.Entry(obj).State == EntityState.Deleted);
            _dbContext.Remove(obj);

            return true;
        }


        public async Task<bool> ClearChangeTracker()
        {
           var entries= _dbContext.ChangeTracker.Entries();

           foreach (var entityEntry in entries)
           {
               _dbContext.Entry(entityEntry).State = EntityState.Detached;
           }
           
           return true;
        }


        public async Task<int> Save(CancellationToken cancellationToken = default(CancellationToken))
        {

           return await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
