using SecKill.Domain.AggregatesModel;

namespace SecKill.Infrastructure.Repositories
{
    public class SecKillOrderRepository : Repository<SeckillOrder>, ISecKillOrderRepository
    {
        public SecKillOrderRepository(DefaultContext dbContext) : base(dbContext)
        {
        }
    }
}
