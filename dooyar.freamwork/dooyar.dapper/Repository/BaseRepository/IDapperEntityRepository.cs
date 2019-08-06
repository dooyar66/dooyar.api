using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.dapper.Repository
{
    public  interface IDapperEntityRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 查询列表数据
        /// </summary>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null);
        /// <summary>
        /// 根据条件获取单个
        /// </summary>
        TEntity Get(Expression<Func<TEntity, bool>> expression = null);

        /// <summary>
        /// 根据Id获取
        /// </summary>
        TEntity GetById(dynamic primaryId);

        Task<TEntity> GetByIdAsync(dynamic primaryId);

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> expression = null);

        /// <summary>
        /// 符合条件的记录是否存
        /// </summary>
        bool Exists(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 插入实体
        /// </summary>>
        bool Insert(TEntity entity);

        Task<dynamic> InsertAsync(TEntity entity);
        /// <summary>
        /// 批量插入实体
        /// </summary>>
        void Insert(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        bool Delete(Expression<Func<TEntity, bool>> expression);

        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 根据Id删除
        /// </summary>
        bool Delete(dynamic primaryId);

        Task<bool> DeleteAsync(dynamic primaryId);
        /// <summary>
        /// 更新
        /// </summary>
        bool Update(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);
    }
}
