using System.Linq.Expressions;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Extensions;

public static class QueryListExtensions
{
    public static IQueryable<TEntity> WhereSpecificIds<TEntity>(this IQueryable<TEntity> query, BaseListQuery listQuery)
        where TEntity : BaseEntity<Guid>
    {
        return query.WhereIf(listQuery.SpecificIdsForFetch?.Any() == true, p => listQuery.SpecificIdsForFetch.Contains(p.Id));
    }

    public static async Task<QueryListResult<TEntity>> ToQueryListResult<TEntity>(this IQueryable<TEntity> query, BaseListQuery listQuery, CancellationToken cancellationToken)
        where TEntity : class //BaseEntity<Guid>
    {
        if (listQuery.OrderByFields?.Any() ?? false)
        {
            for (int index = 0; index < listQuery.OrderByFields.Count; ++index)
                query = query.OrderByDynamic(listQuery.OrderByFields[index], !listQuery.OrderByDescs[index]);
        }

        int totalCount = await query.CountAsync(cancellationToken);

        int startPage = listQuery.StartPage <= 0 ? 0 : listQuery.StartPage;
        int pageSize = listQuery.PageSize <= 0 ? 0 : listQuery.PageSize;
        if (pageSize > 0)
        {
            int count = (startPage - 1) * pageSize;
            query = query.Skip(count).Take(pageSize);
        }

        List<TEntity> results = await query.ToListAsync(cancellationToken);

        return QueryResult.Success(results, totalCount);
    }
    
    
    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> q, string SortField, bool Ascending)
    {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "p");
        LambdaExpression lambdaExpression = Expression.Lambda(Expression.Property(parameterExpression, SortField), parameterExpression);
        MethodCallExpression methodCallExpression = Expression.Call(typeof(Queryable), Ascending ? "OrderBy" : "OrderByDescending", new Type[2]
        {
            q.ElementType,
            lambdaExpression.Body.Type
        }, q.Expression, lambdaExpression);
        return q.Provider.CreateQuery<T>(methodCallExpression);
    }
}