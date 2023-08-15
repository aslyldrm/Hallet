using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Services.JobFilterService
{
    public interface IJobFilterReadRepository 
    {
        public IQueryable<Job> FilterJobsByCityPriceAndCategory(string[] cities, decimal? minPrice, decimal? maxPrice, string[] categories);
    }
}
