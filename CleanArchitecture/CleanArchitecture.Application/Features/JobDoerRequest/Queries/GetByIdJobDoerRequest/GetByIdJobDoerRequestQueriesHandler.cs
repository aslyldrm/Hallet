
using CleanArchitecture.Core.Features.JobRejectedRequest.Queries.GetByIdJobRejectedRequest;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Queries.GetByIdJobDoerRequest
{
    public class GetByIdJobDoerRequestQueriesHandler : IRequestHandler<GetByIdJobDoerRequestQueriesRequest, GetByIdJobDoerRequestQueriesResponse>
    {
        IJobDoerRequestReadRepository _jobDoerRequestReadRepository;

        public GetByIdJobDoerRequestQueriesHandler(IJobDoerRequestReadRepository jobDoerRequestReadRepository)
        {
            _jobDoerRequestReadRepository = jobDoerRequestReadRepository;
        }

        public async Task<GetByIdJobDoerRequestQueriesResponse> Handle(GetByIdJobDoerRequestQueriesRequest request, CancellationToken cancellationToken)
        {
            var record = await _jobDoerRequestReadRepository.GetByCustomCriteriaAsync("JobId", request.JobId);

            if (record != null)
            {
                // Veri bulundu, yapılacak işlemleri gerçekleştirin.
                var response = new GetByIdJobDoerRequestQueriesResponse();

                foreach (var category in record)
                {
                    response.JobDoerRequests.Add(category.JobDoerRequestUserId);
                }


                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
