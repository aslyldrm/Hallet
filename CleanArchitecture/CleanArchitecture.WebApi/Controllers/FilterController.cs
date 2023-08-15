using CleanArchitecture.Core.DTOs.Filter.FilteringJobs;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Services.JobFilterService;
using CleanArchitecture.Infrastructure.Services.JobFilterService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IJobFilterReadRepository _jobFilterReadService;
        

        public FilterController(IJobFilterReadRepository jobFilterReadService)
        {
            _jobFilterReadService = jobFilterReadService;
        }
        [HttpGet("filter")]
        public IActionResult FilterJobs([FromQuery] string cities, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string categories)
        {
            string[] cityArray = !string.IsNullOrEmpty(cities) ? cities.Split(',') : null;
            List<string> categoryList = !string.IsNullOrEmpty(categories) ? categories.Split(',').ToList() : null;

            var filteredJobs = _jobFilterReadService.FilterJobsByCityPriceAndCategory(cityArray, minPrice, maxPrice, categoryList?.ToArray());

            return Ok(filteredJobs);
        }



    }
}
