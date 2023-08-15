using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobRejectedRequest.Queries.GetByIdJobRejectedRequest
{
    public class GetByIdJobRejectedRequestQueriesRequest : IRequest<GetByIdJobRejectedRequestQueriesResponse>
    {
        public string JobId { get; set; }
    }
}
