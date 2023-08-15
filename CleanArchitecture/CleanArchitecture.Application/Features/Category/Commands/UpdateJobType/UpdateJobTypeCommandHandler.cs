using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JopType.Commands.UpdateJobType
{
    public class UpdateJobTypeCommandHandler : IRequestHandler<UpdateJobTypeCommandRequest, UpdateJobTypeCommandResponse>
    {
        readonly ICategoryReadRepository _jobTypeReadRepository;
        readonly ICategoryWriteRepository _jobTypeWriteRepository;

        public UpdateJobTypeCommandHandler(ICategoryReadRepository jobTypeReadRepository, ICategoryWriteRepository jobTypeWriteRepository)
        {
            _jobTypeReadRepository = jobTypeReadRepository;
            _jobTypeWriteRepository = jobTypeWriteRepository;
        }

        public async Task<UpdateJobTypeCommandResponse> Handle(UpdateJobTypeCommandRequest request, CancellationToken cancellationToken)
        {
             var existingJobType = await _jobTypeReadRepository.GetByNameAsync(request.CategoryName);
            if (existingJobType != null)
            {
                throw new Exception("Another category with the same name already exists.");
            }
            Category job = await _jobTypeReadRepository.GetByIdAsync(request.CategoryName);
            job.CategoryName = request.CategoryName;
            await _jobTypeWriteRepository.SaveAsync();
            return new();

        }
    }
}
