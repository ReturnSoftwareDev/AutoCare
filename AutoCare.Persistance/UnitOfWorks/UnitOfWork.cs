using AutoCare.Application.UnitOfWorks;
using AutoCare.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoCareContext _context;

        public UnitOfWork(AutoCareContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var updateEntries = _context.ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Modified);

                foreach ( var entry in updateEntries )
                {
                    var entity = entry.Entity;
                    var updateDateProperty = entity.GetType().GetProperty("UpdatedDate");

                    if(updateDateProperty != null && updateDateProperty.CanWrite) 
                    {
                        updateDateProperty.SetValue(entity, DateTime.Now);
                    }
                }

                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
    }
}
