using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Services.JobFilterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.JobFilterService
{
    public class JobFilterReadService : IJobFilterReadRepository
    {
        readonly IJobReadRepository _jobReadRepository;

        public JobFilterReadService(IJobReadRepository jobReadRepository)
        {
            _jobReadRepository = jobReadRepository;
        }

        public IQueryable<Job> FilterJobsByCityPriceAndCategory(string[] cities, decimal? minPrice, decimal? maxPrice, string[] categories)
        {
            var filteredJobs = _jobReadRepository.GetAll();
            var filters = new List<Expression<Func<Job, bool>>>();

            if (cities != null && cities.Length > 0)
            {
                filters.Add(j => cities.Contains(j.City));
            }

            if (minPrice.HasValue)
            {
                filters.Add(j => Convert.ToDecimal(j.Price) >= minPrice.Value);
            }

            if (maxPrice.HasValue && maxPrice != 0)
            {
                filters.Add(j => Convert.ToDecimal(j.Price) <= maxPrice.Value);
            }

            if (categories != null && categories.Length > 0)
            {
                filters.Add(j => categories.Contains(j.JobType));
            }

            if (filters.Count > 0)
            {
                var queryableJobs = filteredJobs.AsQueryable();

                foreach (var filter in filters)
                {
                    queryableJobs = queryableJobs.Where(filter);
                }

                return queryableJobs;
            }

            return filteredJobs;
        }









    }
}
