using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SecKill.Domain.SeedWork
{
    /// <summary>
    /// 仓库接口
    /// </summary>
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        #region  添加 删除 更新

        /// <summary>
        /// 添加到仓储
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="oldEntity"></param>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        T Update(T oldEntity, T newEntity);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        #endregion

        #region 查询

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns></returns>
        Task<T> GetAsync(object id);

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ListEntities();

        /// <summary>
        /// 原始sql查询
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> SqlQuery(string sqlstr, params object[] parameters);

        /// <summary>
        /// 原始sql查询
        /// </summary>
        /// <param name="sqlstr">sql语句</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TQuery> SqlQuery<TQuery>(string sqlstr, params object[] parameters) where TQuery : class;

        #endregion
    }
}
