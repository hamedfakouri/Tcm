using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence.Ef
{
    public class BaseRepository<TModel, Tkey> : IRepository<TModel, Tkey>
    where TModel : EntityBase<Tkey>
   
    {
        
        public DbContext _tcmContext;
        public BaseRepository(DbContext tcmContext)
        {
            _tcmContext = tcmContext;
        }

        public void Add(TModel entity)
        {

            _tcmContext.Set<TModel>().Add(entity);

        }



        public void Delete(TModel entity)
        {
            _tcmContext.Set<TModel>().Remove(entity);

        }



        public TModel GetById(Tkey id)
        {
            return _tcmContext.Set<TModel>().AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<TModel> Get<T>(Expression<Func<TModel,bool>> expression)
        {
            return _tcmContext.Set<TModel>().AsQueryable().Where(expression);
        }

     
        public IQueryable<TModel> ListAll()
        {
            var list = _tcmContext.Set<TModel>().AsQueryable();
            return list;
        }

        public void Update(TModel entity)
        {
            _tcmContext.Set<TModel>().Update(entity);
        }

    }
}
