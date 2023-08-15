using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobRejectedRequest.Queries.GetByIdJobRejectedRequest
{
    public class GetByIdJobRejectedRequestQueriesResponse
    {
        public List<string> JobRejectedRequests { get; set; } = new List<string>();
    }
}
