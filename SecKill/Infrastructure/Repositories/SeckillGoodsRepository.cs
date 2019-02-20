using SecKill.Domain.AggregatesModel;

namespace SecKill.Infrastructure.Repositories
{
    public class SeckillGoodsRepository : Repository<SeckillGoods>, ISeckillGoodsRepository
    {
        public SeckillGoodsRepository(DefaultContext dbContext) : base(dbContext)
        {
        }
    }
}
