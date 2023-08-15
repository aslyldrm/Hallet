using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Queries.GetByIdJobDoerRequest
{
    public class GetByIdJobDoerRequestQueriesRequest : IRequest<GetByIdJobDoerRequestQueriesResponse>
    {
        public string JobId { get; set; }
    }
}
