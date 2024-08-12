using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;
public interface IAsyncRepository<TEntity, TEntityId> : IQueryable<TEntity>
    where TEntity : Entity<TEntityId>
{
    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool withDeleted = false, //Do not give the deleted ones
        bool enableTracking = true, //Enable EntityFrameworks tracking support
        CancellationToken cancellationToken = default
        );

    Task<IPaginate<TEntity>> GetListAsync( //Pagination - Sayfalama in turkish
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<IPaginate<TEntity>> GetListByDynamicAsync( //For example, amazons option list like what is the brand, model price etc. Search the list for these.
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );

    Task<TEntity> AddAsync(TEntity entity);
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity); //Bulk operation
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);
    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false); //Soft delete or permanent delete - Default option is soft
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false);
}
