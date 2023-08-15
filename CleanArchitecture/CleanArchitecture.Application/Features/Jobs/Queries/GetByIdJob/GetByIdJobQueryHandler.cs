using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetByIdJob
{
    internal class GetByIdJobQueryHandler : IRequestHandler<GetByIdJobQueryRequest, GetByIdJobQueryResponse>
    {
        readonly IJobReadRepository _jobReadRepository;

        public GetByIdJobQueryHandler(IJobReadRepository jobReadRepository)
        {
            _jobReadRepository = jobReadRepository;
        }

        public async Task<GetByIdJobQueryResponse> Handle(GetByIdJobQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                Job job = await _jobReadRepository.GetByIdAsync(request.Id, false);

                if (job == null)
                {
                    throw new Exception("Job not found");
                }

                return new GetByIdJobQueryResponse
                {
                    Title = job.Title,
                    OwnerId = job.OwnerId,
                    JobType = job.JobType,
                    Status = job.Status,
                    Description = job.Description,
                    Price = job.Price,
                    Location = job.Location,
                    City = job.City,
                    CompletedTime = job.CompletedTime,
                    JobDoerId = job.DoerId,
                    JobPosterRequestId = job.JobPosterRequestId,
                    JobPosterRating = job.JobPosterRating,
                    CreatedDate = job.CreatedDate
                    
                    
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
