using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Image.Queries.GetByIdImages
{
    public class GetByIdImagesQueriesRequest : IRequest<GetByIdImagesQueriesResponse>
    {
        public string JobId { get; set; }
    }
}
