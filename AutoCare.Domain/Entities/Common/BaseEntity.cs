using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Domain.Entities.Common;
public class BaseEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; } 
    public bool IsDeleted { get; set; }
}
