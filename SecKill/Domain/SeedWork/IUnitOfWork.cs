using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecKill.Domain.SeedWork
{
    /// <summary>
    /// 工作单元 将多个操作放入一个工作单元中，把操作原子化
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交
        /// </summary>
        int Commit();

        void Rollback();
    }
}
