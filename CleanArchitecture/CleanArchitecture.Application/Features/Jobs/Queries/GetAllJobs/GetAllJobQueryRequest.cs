using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetAllJobs
{
    public class GetAllJobQueryRequest : IRequest<GetByIdJobQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}
