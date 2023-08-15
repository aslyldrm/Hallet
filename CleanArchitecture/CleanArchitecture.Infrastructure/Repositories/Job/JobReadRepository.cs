using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class JobReadRepository : ReadRepository<Job>, IJobReadRepository
    {
        public JobReadRepository(HalletDbContext context) : base(context)
        {
        }
    }
}
