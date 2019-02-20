using Microsoft.EntityFrameworkCore;
using SecKill.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecKill.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        readonly DefaultContext _dbContext;

        public Repository(DefaultContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public T Get(object id)
        {
            return _dbContext.Find<T>(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> ListEntities()
        {
            return _dbContext.Set<T>().AsNoTracking().AsEnumerable();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> SqlQuery(string sqlstr, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TQuery> SqlQuery<TQuery>(string sqlstr, params object[] parameters) where TQuery : class
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            return _dbContext.Set<T>().Update(entity).Entity;
        }

        public T Update(T oldEntity, T newEntity)
        {
            var entry = _dbContext.Entry(oldEntity);
            entry.CurrentValues.SetValues(newEntity);
            return entry.Entity;
        }
    }
}
