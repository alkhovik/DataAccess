using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Core.Extensions;
using DataAccess.Core.Interfaces;

namespace DataAccess.Context.Repositories
{
    public class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public BaseReadOnlyRepository(CustomContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        protected CustomContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }

        public virtual TEntity Get(TKey id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> Get(params Expression<Func<TEntity, object>>[] included)
        {
            return DbSet.IncludeMultiple(included).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] included)
        {
            return DbSet.IncludeMultiple(included).Where(expression).ToList();
        }

        public IEnumerable<TEntity> GetAsNoTracking()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetAsNoTracking(params Expression<Func<TEntity, object>>[] included)
        {
            return DbSet.AsNoTracking().IncludeMultiple(included).ToList();
        }

        public IEnumerable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.AsNoTracking().Where(expression).ToList();
        }

        public IEnumerable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] included)
        {
            return DbSet.AsNoTracking().IncludeMultiple(included).Where(expression).ToList();
        }
    }
}
