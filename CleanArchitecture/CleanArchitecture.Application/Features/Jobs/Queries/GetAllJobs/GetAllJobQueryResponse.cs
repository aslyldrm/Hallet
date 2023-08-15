using CleanArchitecture.Core.Features.Jobs.Queries.GetByIdJob;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetAllJobs
{
    public class GetByIdJobQueryResponse
    {
        public int TotalCount { get; set; }
        public object Jobs { get; set; }

        public static implicit operator GetByIdJobQueryResponse(GetByIdJob.GetByIdJobQueryResponse v)
        {
            throw new NotImplementedException();
        }
    }
}
