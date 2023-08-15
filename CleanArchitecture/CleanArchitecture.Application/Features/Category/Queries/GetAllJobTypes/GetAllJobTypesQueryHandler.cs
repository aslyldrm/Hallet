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

namespace CleanArchitecture.Core.Features.JopType.Queries.GetAllJobTypes
{
    public class GetAllJobTypesQueryHandler : IRequestHandler<GetAllJobTypesQueryRequest, GetAllJobTypesQueryResponse>
    {
        readonly ICategoryReadRepository _jobTypeReadRepository;

        public GetAllJobTypesQueryHandler(ICategoryReadRepository jobTypeReadRepository)
        {
            _jobTypeReadRepository = jobTypeReadRepository;
        }

        public async Task<GetAllJobTypesQueryResponse> Handle(GetAllJobTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var jobTypes = _jobTypeReadRepository.GetAll(false).ToList();


            var response = new GetAllJobTypesQueryResponse
            {
                JobTypes = jobTypes
            };

            return response;
        }
    }
}
