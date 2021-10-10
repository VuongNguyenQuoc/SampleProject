using App.Helpers.Domain;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Helpers.Repository
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        TEntity FindById(Guid id);
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity model);
        IEnumerable<TEntity> GetAll();
        bool Remove(TEntity entity);
    }
}
