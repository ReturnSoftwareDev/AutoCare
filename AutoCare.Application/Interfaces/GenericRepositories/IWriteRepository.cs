using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.GenericRepositories
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Table { get; }


        Task DeleteAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
