using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JopType.Queries.GetAllJobTypes
{
    public class GetAllJobTypesQueryResponse
    {
        public List<Category> JobTypes { get; set; }


    }
}
