using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);

        TEntity GetSingle(Func<TEntity, bool> predicate);

        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void DeleteById(int Id);

        void Delete(TEntity entity);
    }
}
