using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace dooyar.ef.Repository
{
    public interface IRepositroy<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        TEntity GetById(int id);
    }
}
