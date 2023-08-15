using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetByIdJob
{
    public class GetByIdJobQueryRequest :  IRequest<GetByIdJobQueryResponse>
    {
        public string Id { get; set; }
    }
}
