using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Demo.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class 
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
