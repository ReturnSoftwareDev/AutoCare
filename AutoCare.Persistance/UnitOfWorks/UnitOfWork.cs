using AutoCare.Application.UnitOfWorks;
using AutoCare.Persistance.Context;
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
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
    }
}
