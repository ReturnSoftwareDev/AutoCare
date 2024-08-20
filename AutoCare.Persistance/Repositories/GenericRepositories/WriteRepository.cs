using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Repositories.GenericRepositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
    {
        private readonly AutoCareContext _context;

        public WriteRepository(AutoCareContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);

            Table.Remove(entity);   
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
        }
    }
}
