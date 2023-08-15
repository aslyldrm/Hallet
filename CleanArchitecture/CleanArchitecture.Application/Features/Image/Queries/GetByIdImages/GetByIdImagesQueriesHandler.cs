
using CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Repositories.Image;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Image.Queries.GetByIdImages
{
    public class GetByIdImagesQueriesHandler : IRequestHandler<GetByIdImagesQueriesRequest, GetByIdImagesQueriesResponse>
    {
        readonly IReadImageRepository _imageReadRepository;

        public GetByIdImagesQueriesHandler(IReadImageRepository imageReadRepository)
        {
            _imageReadRepository = imageReadRepository;
        }

        public async Task<GetByIdImagesQueriesResponse> Handle(GetByIdImagesQueriesRequest request, CancellationToken cancellationToken)
        {

            var record = await _imageReadRepository.GetByCustomCriteriaAsync("JobId", request.JobId);
     

            if (record != null)
            {
                // Veri bulundu, yapılacak işlemleri gerçekleştirin.
                var response = new GetByIdImagesQueriesResponse();

                foreach (var category in record)
                {
                    response.JobImages.Add(category.JobImage);
                }


                return response;
            }
            else
            {
                return null;
            }

        
        }
    }
}
