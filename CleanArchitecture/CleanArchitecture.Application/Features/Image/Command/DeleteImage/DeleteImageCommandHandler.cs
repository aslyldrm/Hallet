using CleanArchitecture.Core.Features.JobDoerRequest.Commands.DeleteJobDoerRequest;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Repositories.Image;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Image.Command.DeleteImage
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommandRequest, DeleteImageCommandResponse>
    {
        readonly IWriteImageRepository _imageWriteRepository;
        readonly IReadImageRepository _imageReadRepository;

        public DeleteImageCommandHandler(IWriteImageRepository imageWriteRepository, IReadImageRepository imageReadRepository)
        {
            _imageWriteRepository = imageWriteRepository;
            _imageReadRepository = imageReadRepository;
        }

        public async Task<DeleteImageCommandResponse> Handle(DeleteImageCommandRequest request, CancellationToken cancellationToken)
        {
            int deletedRowCount = await _imageWriteRepository.DeleteByCustomCriteriaAsync(request.JobId, request.ImageName,"JobId","JobImage");

            if (deletedRowCount > 0)
            {
                // İşlem başarılı oldu, isteğe bağlı olarak bir yanıt döndürebilirsiniz.
                DeleteImageCommandResponse response = new DeleteImageCommandResponse
                {
                    Success = true,
                    Message = $"Successfully deleted {deletedRowCount} job image(s)."
                };


                return response;

            }
            else
            {

                throw new Exception("Failed to delete job image(s).");
            }
        }
    }
}
