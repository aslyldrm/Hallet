using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface ICategoryReadRepository : IReadRepository<Category>
    {
        Task<Category> GetByNameAsync(string name);
    }
}
