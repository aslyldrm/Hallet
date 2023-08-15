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
    public class JobRejectedRequestReadRepository : ReadRepository<JobRejectedRequest>, IJobRejectedRequestReadRepository
    {
        public JobRejectedRequestReadRepository(HalletDbContext context) : base(context)
        {
        }
    }
}
