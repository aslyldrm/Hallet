using CleanArchitecture.Core.Interfaces.Repositories.Image;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Features.Image.Command.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommandRequest, UpdateImageCommandResponse>
    {
        readonly IWriteImageRepository _imageWriteRepository;
        readonly IReadImageRepository _imageReadRepository;

        public UpdateImageCommandHandler(IWriteImageRepository imageWriteRepository, IReadImageRepository imageReadRepository)
        {
            _imageWriteRepository = imageWriteRepository;
            _imageReadRepository = imageReadRepository;
        }

        public async Task<UpdateImageCommandResponse> Handle(UpdateImageCommandRequest request, CancellationToken cancellationToken)
        {
            var images = _imageReadRepository.GetAll(false);

            var filteredImages = images.Where(j => j.JobId == request.JobId && j.JobImage == request.ImageName);

            foreach (var image in filteredImages)
            {
                image.JobImage = request.NewImageName;
            
            }

            await _imageWriteRepository.SaveAsync();

            return new();
        }
    }
}
