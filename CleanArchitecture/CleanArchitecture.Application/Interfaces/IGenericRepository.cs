using CleanArchitecture.Core.Entities.Common;
using System;

using System.Collections.Generic;

using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity { 
        DbSet<T> Table { get; }
    }
}
