using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.DeleteUserCategories
{
    public class DeleteUserCategoriesCommandRequest : IRequest<DeleteUserCategoriesCommandResponse>
    {
        public string UserId { get; set; }
        public string CategoryName { get; set; }
    }
}
