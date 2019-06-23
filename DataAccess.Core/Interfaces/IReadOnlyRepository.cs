using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Core.Entities;

namespace DataAccess.Core.Interfaces
{
    public interface IReadOnlyRepository<TEntity, in TKey> : IRepository
        where TEntity : IEntity<TKey>
    {
        TEntity Get(TKey id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(params Expression<Func<TEntity, object>>[] included);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] included);

        IEnumerable<TEntity> GetAsNoTracking();

        IEnumerable<TEntity> GetAsNoTracking(params Expression<Func<TEntity, object>>[] included);

        IEnumerable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> GetAsNoTracking(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] included);
    }
}
