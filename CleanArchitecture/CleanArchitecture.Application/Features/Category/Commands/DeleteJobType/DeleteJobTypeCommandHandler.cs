using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JopType.Commands.DeleteJobType
{
    public class DeleteJobTypeCommandHandler : IRequestHandler<DeleteJobTypeCommandRequest, DeleteJobTypeCommandResponse>
    {
        readonly ICategoryWriteRepository _jobTypeWriteRepository;

        public DeleteJobTypeCommandHandler(ICategoryWriteRepository jobTypeWriteRepository)
        {
            _jobTypeWriteRepository = jobTypeWriteRepository;
        }

        public async Task<DeleteJobTypeCommandResponse> Handle(DeleteJobTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _jobTypeWriteRepository.RemoveAsync(request.CategoryName);
            await _jobTypeWriteRepository.SaveAsync();
            return new();
        }
    }
}
