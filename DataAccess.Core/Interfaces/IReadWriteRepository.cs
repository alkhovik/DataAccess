using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Core.Entities;

namespace DataAccess.Core.Interfaces
{
    public interface IReadWriteRepository<TEntity, in TKey> : IReadOnlyRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TKey id);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TKey> ids);

        void Delete(IEnumerable<TEntity> entities);

        void Delete(Expression<Func<TEntity, bool>> expression);
    }
}
