using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        readonly IUserReadRepository _userReadRepository;

        public GetByIdUserQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
      
            User user = await _userReadRepository.GetByIdAsync(request.Id, false);
            //job type table2ına eklenecek
            return new()
            {
                Name = user.Name,
                Surname  = user.Surname,
                Email = user.Email,
                Rating = user.Rating,
                Image = user.Image,
                CompletedJobs = user.CompletedJobs,
        
                CreatedDate = user.CreatedDate
                
    };

        }


      
    }
}
