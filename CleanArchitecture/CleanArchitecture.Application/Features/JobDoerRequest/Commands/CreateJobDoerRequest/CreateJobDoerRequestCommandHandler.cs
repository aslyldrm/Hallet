using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.CreateJobDoerRequest
{
    public class CreateJobDoerRequestCommandHandler : IRequestHandler<CreateJobDoerRequestCommandRequest, CreateJobDoerRequestCommandResponse>
    {

        IJobDoerRequestWriteRepository _jobDoerRequestWriteRepository;

        public CreateJobDoerRequestCommandHandler( IJobDoerRequestWriteRepository jobDoerRequestWriteRepository)
        {
    
            _jobDoerRequestWriteRepository = jobDoerRequestWriteRepository;
        }

        public async Task<CreateJobDoerRequestCommandResponse> Handle(CreateJobDoerRequestCommandRequest request, CancellationToken cancellationToken)
        {
            await _jobDoerRequestWriteRepository.AddAsync(new()
            {
                JobId = request.JobId,
                JobDoerRequestUserId = request.JobDoerUserId

            });
            await _jobDoerRequestWriteRepository.SaveAsync();


            return new();

        }
    }
}
