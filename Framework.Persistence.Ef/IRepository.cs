using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Framework.Persistence.Ef
{
    public interface IRepository<T, Tkey> :IRepositoryMarker
    {
        T GetById(Tkey id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

    }
}
