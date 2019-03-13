using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity GetByName(string name);

        TEntity GetSingle(Func<TEntity, bool> predicate);

        IQueryable<TEntity> GetByName();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void DeleteById(int Id);

        void Delete(TEntity entity);
    }
}
