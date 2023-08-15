
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories
{
    public class GetByIdUserCategoriesRequest : IRequest<GetByIdUserCategoriesResponse>
    {
        public string UserId { get; set; }
    }
}
