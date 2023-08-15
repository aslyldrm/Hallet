using CleanArchitecture.Core.Features.Image.Command.DeleteImage;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using CleanArchitecture.Core.Features.JopType.Queries.GetAllJobTypes;

using CleanArchitecture.Core.Features.JopType.Commands.CreateJobType;
using CleanArchitecture.Core.Features.JopType.Commands.UpdateJobType;
using CleanArchitecture.Core.Features.JopType.Commands.DeleteJobType;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllJobTypesQueryRequest getAllJobTypeQueryRequest)
        {
           GetAllJobTypesQueryResponse response = await _mediator.Send(getAllJobTypeQueryRequest);

            return Ok(response);

        }



        [HttpPost]
        public async Task<IActionResult> CreateOneJob([FromBody] CreateJobTypeCommandRequest createJobTypeCommandRequest)
        {
            if(_mediator == null) {
                Console.WriteLine("Bosss");
            }
            CreateJobTypeCommandResponse response = await _mediator.Send(createJobTypeCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOneJob([FromBody] UpdateJobTypeCommandRequest updateJobTypeCommandRequest)
        {
            UpdateJobTypeCommandResponse response = await _mediator.Send(updateJobTypeCommandRequest);

            return Ok();


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOneJob([FromRoute] DeleteJobTypeCommandRequest deleteJobTypeCommandRequest)
        {
            DeleteJobTypeCommandResponse response = await _mediator.Send(deleteJobTypeCommandRequest);

            return Ok();
        }
       

    }
}
