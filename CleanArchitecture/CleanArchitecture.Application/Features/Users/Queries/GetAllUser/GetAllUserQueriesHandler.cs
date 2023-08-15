using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueriesHandler : IRequestHandler<GetAllUserQueriesRequest, GetAllUserQueriesResponse>
    {
        readonly IUserReadRepository _userReadRepository;

        public GetAllUserQueriesHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<GetAllUserQueriesResponse> Handle(GetAllUserQueriesRequest request, CancellationToken cancellationToken)
        {

            var users = _userReadRepository.GetAll(false)
       .Select(u => new User
       {
           Id = u.Id,
           Name = u.Name,
           Surname = u.Surname,
           Email = u.Email,
           Rating = u.Rating,
           Image = u.Image,
           CompletedJobs = u.CompletedJobs,
           Expires = u.Expires
       })
       .ToList();

            return new GetAllUserQueriesResponse
            {
                AllUser = users

       
    };
            /*
            var users = _userReadRepository.GetAll(false).ToList();
            GetAllUserQueriesResponse response = new GetAllUserQueriesResponse();
            response.AllUser = users;
            return response;
            */
            /*
            var users = _userReadRepository.GetAll(false).ToList();
            GetAllUserQueriesResponse response = new GetAllUserQueriesResponse();
            response.AllUser = users.Select(u => new User { Id = u.Id, Rating = u.Rating }).ToList();
            return response;
            */



        }
    }
}
