using CleanArchitecture.Core.Features.JobDoerRequest.Queries.GetByIdJobDoerRequest;
using CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JobRejectedRequest.Queries.GetByIdJobRejectedRequest
{
    public class GetByIdJobRejectedRequestQueriesHandler : IRequestHandler<GetByIdJobRejectedRequestQueriesRequest, GetByIdJobRejectedRequestQueriesResponse>
    {
        IJobRejectedRequestReadRepository _jobRejectedRequestReadRepository;

        public GetByIdJobRejectedRequestQueriesHandler(IJobRejectedRequestReadRepository jobRejectedRequestReadRepository)
        {
            _jobRejectedRequestReadRepository = jobRejectedRequestReadRepository;
        }

        public async Task<GetByIdJobRejectedRequestQueriesResponse> Handle(GetByIdJobRejectedRequestQueriesRequest request, CancellationToken cancellationToken)
        {


            var record = await _jobRejectedRequestReadRepository.GetByCustomCriteriaAsync("JobId", request.JobId);
     
            if (record != null)
            {
                // Veri bulundu, yapılacak işlemleri gerçekleştirin.
                var response = new GetByIdJobRejectedRequestQueriesResponse();

                foreach (var category in record)
                {
                    response.JobRejectedRequests.Add(category.JobDoerRejectedUserId);
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
