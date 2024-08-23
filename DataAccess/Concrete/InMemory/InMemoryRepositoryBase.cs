using Core.Entity.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public abstract class InMemoryRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() 
    {
        protected readonly InMemoryContext _context;
        protected abstract List<TEntity> _entities { get; }

        protected InMemoryRepositoryBase(InMemoryContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            TEntity entityToDelete = _entities.SingleOrDefault(e => e.Id == entity.Id);
            _entities.Remove(entityToDelete);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.AsQueryable().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _entities
                : _entities.AsQueryable().Where(filter).ToList();
        }

        public virtual void Update(TEntity entity)
        {
        }
        
    }
}
