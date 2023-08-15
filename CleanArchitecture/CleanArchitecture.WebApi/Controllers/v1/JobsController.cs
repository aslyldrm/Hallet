using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Image.Command.CreateImages;
//using CleanArchitecture.Core.Entities.Identity;
using CleanArchitecture.Core.Features.Image.Command.DeleteImage;
using CleanArchitecture.Core.Features.Image.Command.UpdateImage;
using CleanArchitecture.Core.Features.Image.Queries.GetByIdImages;
using CleanArchitecture.Core.Features.Jobs.Commands.CreateJob;
using CleanArchitecture.Core.Features.Jobs.Commands.DeleteJob;
using CleanArchitecture.Core.Features.Jobs.Commands.UpdateJob;
using CleanArchitecture.Core.Features.Jobs.Queries.GetAllJobs;
using CleanArchitecture.Core.Features.Jobs.Queries.GetByIdJob;
using CleanArchitecture.Core.Interfaces;

using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        readonly private IJobWriteRepository _jobWriteRepository;
        readonly private IJobReadRepository _jobReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IConfiguration configuration;


        readonly IMediator _mediator;
        public JobsController(IJobWriteRepository jobWriteRepository,
            IJobReadRepository jobReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IMediator mediator)
        {
            _jobWriteRepository = jobWriteRepository;
            _jobReadRepository = jobReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs([FromQuery] GetAllJobQueryRequest getAllJobQueryRequest)
        {
            Core.Features.Jobs.Queries.GetAllJobs.GetByIdJobQueryResponse response = await _mediator.Send(getAllJobQueryRequest);

            return Ok(response);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOneJob([FromRoute]GetByIdJobQueryRequest getByIdJobQueryRequest)
        {
            Core.Features.Jobs.Queries.GetByIdJob.GetByIdJobQueryResponse response = await _mediator.Send(getByIdJobQueryRequest);
            if (response == null)
            {
                Console.WriteLine("girmedi");
            }
            return Ok(response);
        }

     
        [HttpPost]
        public async Task<IActionResult> CreateOneJob([FromBody] CreateJobCommandRequest createJobCommandRequest)
        {
            CreateJobCommandResponse response = await _mediator.Send(createJobCommandRequest);
            if(response.Success ==  true)
            {
                return Ok(response);

            }
            else
            {
                return BadRequest(response);
            }
          
        }
     
        
        [HttpPut]
        public async Task<IActionResult> UpdateOneJob([FromBody]UpdateJobCommandRequest updateJobCommandRequest)
        {
          UpdateJobCommandResponse response =  await _mediator.Send(updateJobCommandRequest);

            if (response.Success == true)
            {
                return Ok(response);

            }
            else
            {
                return BadRequest(response);
            }


        }
        
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOneJob([FromRoute] DeleteJobCommandRequest deleteJobCommandRequest)
        {
           DeleteJobCommandResponse response = await _mediator.Send(deleteJobCommandRequest);
   
            return Ok();
        }

        [HttpPost("Image")]
        public async Task<IActionResult> CreateImages([FromBody] CreateImageCommandRequest createImageCommandRequest)
        {
            CreateImageCommandResponse response = await _mediator.Send(createImageCommandRequest);

            if(response == null)
            {
                return BadRequest("Image's number should not bigger than 4");
            }
            return Ok();

        }
        [HttpPut("Image")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageCommandRequest updateImageCommandRequest)
        {
            UpdateImageCommandResponse response = await _mediator.Send(updateImageCommandRequest);

            if (response == null)
            {
                return BadRequest("job notFound");
            }
            return Ok();

        }
        [HttpGet("{JobId}/Images")]
        public async Task<IActionResult> GetByIdImages([FromRoute] GetByIdImagesQueriesRequest getByIdImagesQueriesRequest)
        {
            GetByIdImagesQueriesResponse response = await _mediator.Send(getByIdImagesQueriesRequest);


            if (response == null)
            {
                return BadRequest("job notFound");
            }
            return Ok(response);

        }
        [HttpDelete("{JobId}/{ImageName}/Image")]
        public async Task<IActionResult> DeleteOneImage([FromRoute] DeleteImageCommandRequest deleteImageCommandRequest)
        {
            DeleteImageCommandResponse response = await _mediator.Send(deleteImageCommandRequest);

            return Ok(response);

        }



     

    }
}

