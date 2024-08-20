using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Repositories.GenericRepositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class
    {
        private readonly AutoCareContext _context;

        public ReadRepository(AutoCareContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>(); 

        public async Task<List<TEntity>?> GetAllAsync() => await Table.AsNoTracking().ToListAsync();

        public async Task<List<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> values = Table;

            if(filter is not null)
                values = values.Where(filter);

            if (includes is not null)
                foreach (var include in includes)
                {
                    values = values.Include(include);
                }

            if (orderBy is not null)
                values = orderBy(values);

            return await values.AsNoTracking().ToListAsync();

        }

        public async Task<int> GetCountAsync() => await Table.CountAsync();

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter) => await Table.Where(filter).CountAsync();

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter) => await Table.FirstOrDefaultAsync(filter);

        public async Task<TEntity> GetSingleByIdAsync<TId>(TId id) => await Table.FindAsync(id);
    }
}
