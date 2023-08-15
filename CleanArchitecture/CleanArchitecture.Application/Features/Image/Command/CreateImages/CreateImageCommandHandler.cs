using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Image.Command.CreateImages
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommandRequest, CreateImageCommandResponse>
    {
        IWriteImageRepository _writeImageRepository;

        public CreateImageCommandHandler(IWriteImageRepository writeImageRepository)
        {
            _writeImageRepository = writeImageRepository;
        }

        public async Task<CreateImageCommandResponse> Handle(CreateImageCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.JobImages.Count > 4)
            {
                return null ;

               // new Exception("Images number should not bigger than 4")
            }

            foreach(var image in request.JobImages)
            {
                await _writeImageRepository.AddAsync(new()
                {
                    JobId = request.JobId,
                    JobImage = image

                });

            }
           
            await _writeImageRepository.SaveAsync();


            

            return new();
        }
    }
}
