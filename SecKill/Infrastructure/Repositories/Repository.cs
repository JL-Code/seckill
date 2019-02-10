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
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ListEntities()
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public T Update(T oldEntity, T newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
