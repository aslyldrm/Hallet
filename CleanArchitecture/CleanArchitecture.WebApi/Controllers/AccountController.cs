
using CleanArchitecture.Core.DTOs.Account;
using CleanArchitecture.Core.Features.Image.Command.DeleteImage;
using CleanArchitecture.Core.Features.Image.Queries.GetByIdImages;
using CleanArchitecture.Core.Features.JobDoerRequest.Commands.CreateJobDoerRequest;
using CleanArchitecture.Core.Features.JobDoerRequest.Commands.DeleteJobDoerRequest;
using CleanArchitecture.Core.Features.JobDoerRequest.Queries.GetByIdJobDoerRequest;
using CleanArchitecture.Core.Features.JobRejectedRequest.Queries.GetByIdJobRejectedRequest;
using CleanArchitecture.Core.Features.JopType.Commands.DeleteJobType;
using CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories;
using CleanArchitecture.Core.Features.UserCategory.Commands.CreateUserCategories;
using CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories;
using CleanArchitecture.Core.Features.UserCategory.Commands.UpdateUserCategory;

using CleanArchitecture.Core.Features.Users.Command.LoginUser;
using CleanArchitecture.Core.Features.Users.Command.RegisterUser;
using CleanArchitecture.Core.Features.Users.Command.UpdateUser;
using CleanArchitecture.Core.Features.Users.Queries.GetAllUser;
using CleanArchitecture.Core.Features.Users.Queries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
    
        public AccountController(IMediator mediator)
        {
           
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest createUserCommandRequest)
        {

            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest authenticationRequest)
        {

            AuthenticationResponse response = await _mediator.Send(authenticationRequest);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = response.RefreshTokenExpires
            };
            Response.Cookies.Append("refreshToken", response.RefreshToken, cookieOptions);

           
            if (response != null)
            {
                return Ok(response);

            }
            else
            {
                return BadRequest("Your email or password wrong");
            }

        }
        [HttpGet("{Id}"), Authorize]
        public async Task<IActionResult> GetUser([FromRoute] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQueryRequest);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User could not found");
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse response = await _mediator.Send(updateUserCommandRequest);
            if (response != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("User could not found");
            }

        }

        [HttpGet("GetAllUser"), Authorize]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserQueriesRequest getAllUserQueriesRequest)
        {
            GetAllUserQueriesResponse response = await _mediator.Send(getAllUserQueriesRequest);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Empty list");
            }

        }



        [HttpPost("Categories"), Authorize]
        public async Task<IActionResult> CreateUserCategories(CreateUserCategoriesCommandRequest createUserCategoriesCommandRequest)
        {
            CreateUserCategoriesCommandResponse response = await _mediator.Send(createUserCategoriesCommandRequest);
            if (response != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Please check your categories");
            }


        }

        [HttpDelete("{UserId}/{CategoryName}/Category"), Authorize]
        public async Task<IActionResult> DeleteOneJob([FromRoute] DeleteUserCategoriesCommandRequest deleteUserCategoriesCommandRequest)
        {
            DeleteUserCategoriesCommandResponse response = await _mediator.Send(deleteUserCategoriesCommandRequest);

            return Ok();
        }

        [HttpPut("Categories"), Authorize]
        public async Task<IActionResult> UpdateUserCategories([FromBody] UpdateUserCategoryRequest updateUserCategoryRequest)
        {
            UpdateUserCategoryResponse response = await _mediator.Send(updateUserCategoryRequest);

            return Ok(response);
        }

        [HttpGet("{UserId}/UserCategories"), Authorize]
        public async Task<IActionResult> GetByIdUserCategories([FromRoute] GetByIdUserCategoriesRequest getByIdUserCategoriesRequest)
        {
            GetByIdUserCategoriesResponse response = await _mediator.Send(getByIdUserCategoriesRequest);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User could not found");
            }
        }

        [HttpPost("JobDoerRequest"), Authorize]
        public async Task<IActionResult> CreateJobDoerRequest(CreateJobDoerRequestCommandRequest createJobDoerRequestCommandRequest)
        {
            CreateJobDoerRequestCommandResponse response = await _mediator.Send(createJobDoerRequestCommandRequest);
            if (response != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Job couldn't found");
            }


        }

        /*

        [HttpDelete("{JobId}/{JobDoerUserId}/JobDoerRequest"), Authorize]
        public async Task<IActionResult> DeleteJobDoerRequest([FromRoute] DeleteJobDoerRequestCommandRequest deleteJobDoerRequestCommandRequest)
        {
            DeleteJobDoerRequestCommandResponse response = await _mediator.Send(deleteJobDoerRequestCommandRequest);

            return Ok();
        }
        */
        [HttpGet("{JobId}/JobDoerRequest"), Authorize]
        public async Task<IActionResult> GetByIdJobDoerRequest([FromRoute] GetByIdJobDoerRequestQueriesRequest getByIdJobDoerRequestQueriesRequest)
        {
            GetByIdJobDoerRequestQueriesResponse response = await _mediator.Send(getByIdJobDoerRequestQueriesRequest);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User could not found");
            }
        }



        [HttpGet("{JobId}/JobRejectedRequest"), Authorize]
        public async Task<IActionResult> GetByIdJobRejectedRequest([FromRoute] GetByIdJobRejectedRequestQueriesRequest getByIdJobRejectedRequestQueriesRequest)
        {
            GetByIdJobRejectedRequestQueriesResponse response = await _mediator.Send(getByIdJobRejectedRequestQueriesRequest);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("User could not found");
            }
        }

    }
}
