using Microsoft.EntityFrameworkCore;
using SecKill.Domain.SeedWork;
using System.Linq;

namespace SecKill.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _dbContext;

        public UnitOfWork(DefaultContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(o => o.State = EntityState.Unchanged);
        }
    }
}
