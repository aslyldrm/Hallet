using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class JobDoerRequestReadRepository : ReadRepository<JobDoerRequest>, IJobDoerRequestReadRepository
    {
        public JobDoerRequestReadRepository(HalletDbContext context) : base(context)
        {
        }
    }
}