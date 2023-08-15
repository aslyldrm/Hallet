using CleanArchitecture.Core.Features.Jobs.Commands.CreateJob;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JopType.Commands.CreateJobType
{
    public class CreateJobTypeCommandHandler : IRequestHandler<CreateJobTypeCommandRequest, CreateJobTypeCommandResponse>
    {
        readonly ICategoryWriteRepository _jobTypeWriteRepository;
        readonly ICategoryReadRepository _jobTypeReadRepository;

        public CreateJobTypeCommandHandler(ICategoryWriteRepository jobTypeWriteRepository, ICategoryReadRepository jobTypeReadRepository) 
        {
            _jobTypeReadRepository = jobTypeReadRepository;
            _jobTypeWriteRepository = jobTypeWriteRepository;
        }

      

        public async Task<CreateJobTypeCommandResponse> Handle(CreateJobTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var existingJobType = await _jobTypeReadRepository.GetByNameAsync(request.TypeName);
            if (existingJobType != null)
            {
                throw new Exception("Another category with the same name already exists.");
            }
            await _jobTypeWriteRepository.AddAsync(new()
            {
                CategoryName = request.TypeName,

            });
            await _jobTypeWriteRepository.SaveAsync();


            return new CreateJobTypeCommandResponse();
        }
    }
}
