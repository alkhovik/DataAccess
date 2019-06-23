using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
