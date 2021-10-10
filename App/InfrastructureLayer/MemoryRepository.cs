using App.DomainModelLayer.DbContexts;
using App.Helpers.Domain;
using App.Helpers.Repository;
using App.Helpers.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InfrastructureLayer
{
    public class MemoryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        //protected static List<TEntity> entities = new List<TEntity>();
        private readonly SampleprojectContext _context;
        public MemoryRepository(SampleprojectContext context)
        {
            _context = context;
        }
        public TEntity FindById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            return _context.Set<TEntity>().Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            return _context.Set<TEntity>().Where(spec.IsSatisfiedBy);
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
               
            }
         
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity Update(TEntity model)
        {
            try
            {
                _context.Set<TEntity>().Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
           
            
        }
    }
}
