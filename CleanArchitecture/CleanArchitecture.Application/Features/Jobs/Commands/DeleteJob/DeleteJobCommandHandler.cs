using CleanArchitecture.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommandRequest, DeleteJobCommandResponse>
    {
        readonly IJobWriteRepository _jobWriteRepository;

        public DeleteJobCommandHandler(IJobWriteRepository jobWriteRepository)
        {
            _jobWriteRepository = jobWriteRepository;
        }

        public async Task<DeleteJobCommandResponse> Handle(DeleteJobCommandRequest request, CancellationToken cancellationToken)
        {
            await _jobWriteRepository.RemoveAsync(request.Id);
            await _jobWriteRepository.SaveAsync();
            return new();
      
        }
    }
}
