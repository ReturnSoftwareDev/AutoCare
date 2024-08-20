using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
