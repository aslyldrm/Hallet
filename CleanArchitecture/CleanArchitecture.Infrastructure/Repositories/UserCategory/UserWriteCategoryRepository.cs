using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserWriteCategoryRepository : WriteRepository<UserCategory>, IUserWriteCategoryRepository
    {
        public UserWriteCategoryRepository(HalletDbContext context) : base(context)
        {
        }
    }
}
