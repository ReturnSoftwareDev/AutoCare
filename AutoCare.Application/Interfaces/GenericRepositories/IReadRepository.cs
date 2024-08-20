using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.GenericRepositories
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Table { get; }

        Task<List<TEntity>?> GetAllAsync();
        Task<List<TEntity>?> GetAllAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            params Expression<Func<TEntity, object>>[]? includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetSingleByIdAsync<TId>(TId id);
        Task<int> GetCountAsync();
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter);
    }
}
