using CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.DeleteJobDoerRequest
{
    public class DeleteJobDoerRequestCommandHandler : IRequestHandler<DeleteJobDoerRequestCommandRequest, DeleteJobDoerRequestCommandResponse>
    {
        IJobDoerRequestReadRepository _jobDoerRequestReadRepository;
        IJobDoerRequestWriteRepository _jobDoerRequestWriteRepository;
        IJobRejectedRequestWriteRepository _jobRejectedRequestWriteRepository;

        public DeleteJobDoerRequestCommandHandler(IJobDoerRequestReadRepository jobDoerRequestReadRepository, IJobDoerRequestWriteRepository jobDoerRequestWriteRepository, IJobRejectedRequestWriteRepository jobRejectedRequestWriteRepository)
        {
            _jobDoerRequestReadRepository = jobDoerRequestReadRepository;
            _jobDoerRequestWriteRepository = jobDoerRequestWriteRepository;
            _jobRejectedRequestWriteRepository = jobRejectedRequestWriteRepository;
        }

        public async Task<DeleteJobDoerRequestCommandResponse> Handle(DeleteJobDoerRequestCommandRequest request, CancellationToken cancellationToken)
        {

            int deletedRowCount = await _jobDoerRequestWriteRepository.DeleteByCustomCriteriaAsync(request.JobId, request.JobDoerUserId,"JobId","JobDoerRequestUserId");

            if (deletedRowCount > 0)
            {
                // İşlem başarılı oldu, isteğe bağlı olarak bir yanıt döndürebilirsiniz.
                DeleteJobDoerRequestCommandResponse response = new DeleteJobDoerRequestCommandResponse
                {
                    Success = true,
                    Message = $"Successfully deleted {deletedRowCount} job doer request(s)."
                };
                await _jobRejectedRequestWriteRepository.AddAsync(new()
                {
                    JobId = request.JobId,
                    JobDoerRejectedUserId = request.JobDoerUserId

                });
                await _jobRejectedRequestWriteRepository.SaveAsync();

                return response;

            }
            else
            {
         
                throw new Exception("Failed to delete job doer request(s).");
            }
   


          

        }
    }
}
