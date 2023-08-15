using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.UpdateUserCategory
{
    public class UpdateUserCategoryRequest : IRequest<UpdateUserCategoryResponse>
    {
        public string UserId { get; set; }
        public string UserCategoryName { get; set; }
    }
}
