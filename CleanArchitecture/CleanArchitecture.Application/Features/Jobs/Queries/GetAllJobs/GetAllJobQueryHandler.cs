using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetAllJobs
{
    public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQueryRequest, GetByIdJobQueryResponse>
    {
        readonly IJobReadRepository _jobReadRepository;

        public GetAllJobQueryHandler(IJobReadRepository jobReadRepository)
        {
            _jobReadRepository = jobReadRepository;
        }

        public async Task<GetByIdJobQueryResponse> Handle(GetAllJobQueryRequest request,
            CancellationToken cancellationToken)
        {
            var totalCount = _jobReadRepository.GetAll(false).Count();
            var jobs = _jobReadRepository.GetAll(false).
            Skip(request.Pagination.Page * request.Pagination.Size).
            Take(request.Pagination.Size).Select(p => new
            {
                p.Id,
                p.JobType,
                p.Status,
                p.OwnerId,
                    p.Description,
                    p.Price,
                    // p.Image,
                   // p.JobDoerRating,
                    p.JobPosterRating,
                    p.Title,
                    p.CompletedTime,
                    p.DoerId,
                    p.CreatedDate,
                    p.Location,
                    p.City,
                    p.JobPosterRequestId
                   


                }).ToList();

            return new GetByIdJobQueryResponse
            {
                TotalCount = totalCount,
                Jobs = jobs
            };
        }
    }
}
