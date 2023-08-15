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
    public class JobRejectedRequestWriteRepository : WriteRepository<JobRejectedRequest>, IJobRejectedRequestWriteRepository
    {
        public JobRejectedRequestWriteRepository(HalletDbContext context) : base(context)
        {
        }
    }
}
