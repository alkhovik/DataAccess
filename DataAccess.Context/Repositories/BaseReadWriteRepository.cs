using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Core.Interfaces;

namespace DataAccess.Context.Repositories
{
    public class BaseReadWriteRepository<TEntity, TKey> : BaseReadOnlyRepository<TEntity, TKey>, IReadWriteRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseReadWriteRepository(CustomContext context) : base(context)
        {
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            return DbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }

                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TKey id)
        {
            var entityToDelete = Get(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public virtual void Delete(IEnumerable<TKey> ids)
        {
            var entities = new List<TEntity>();
            foreach (var id in ids)
            {
                var entity = Get(id);
                entities.Add(entity);
            }

            Delete(entities);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            entities = entities.ToList();
            foreach (var entity in entities)
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
            }

            DbSet.RemoveRange(entities);
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            Delete(GetWithTracking(expression));
        }

        private IEnumerable<TEntity> GetWithTracking(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        } 
    }
}