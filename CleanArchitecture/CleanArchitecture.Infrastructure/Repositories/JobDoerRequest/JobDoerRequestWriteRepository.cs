using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
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
    public class JobDoerRequestWriteRepository : WriteRepository<JobDoerRequest>, IJobDoerRequestWriteRepository
    {
        private readonly HalletDbContext _dbContext;
        public JobDoerRequestWriteRepository(HalletDbContext context, HalletDbContext dbContext) : base(context)
        {
            _dbContext = dbContext;
        }

        public void DeleteAndSaveData(string jobDoerRequestUserId)
        {
            var dataToDelete = _dbContext.JobDoerRequest.Where(u => u.JobDoerRequestUserId == jobDoerRequestUserId).ToList();

            foreach (var data in dataToDelete)
            {
                var jobRejectedRequest  = new JobRejectedRequest
                {
                    JobDoerRejectedUserId = data.JobDoerRequestUserId,
                    JobId = data.JobId
                    // Diğer alanlar
                };

                _dbContext.JobRejectedRequest.Add(jobRejectedRequest);
                _dbContext.JobDoerRequest.Remove(data);
            }

            _dbContext.SaveChanges();
        }
    }
}
