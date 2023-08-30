using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Hupo.Template.Infrastructure.Data;

public static class DbSetExtensions
{
    public static Task EnsureCollectionLoadedAsync<TEntity, TProperty>(
        this DbSet<TEntity> dbSet,
        TEntity entity,
        Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class, IEntity
        where TProperty : class

    {
        return dbSet.Entry(entity).Collection(propertyExpression).LoadAsync(cancellationToken);
    }

    public static Task EnsurePropertyLoadedAsync<TEntity, TProperty>(
        this DbSet<TEntity> dbSet,
        TEntity entity,
        Expression<Func<TEntity, TProperty?>> propertyExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class, IEntity
        where TProperty : class

    {
        return dbSet.Entry(entity).Reference(propertyExpression).LoadAsync(cancellationToken);
    }
}
