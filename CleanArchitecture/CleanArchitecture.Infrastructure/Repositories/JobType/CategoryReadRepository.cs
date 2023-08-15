using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        private readonly HalletDbContext _dbContext;
        public CategoryReadRepository(HalletDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Category> GetByNameAsync(string name)
        {
            return await _dbContext.Category.FirstOrDefaultAsync(j => j.CategoryName == name);
        }
    
    }
}
