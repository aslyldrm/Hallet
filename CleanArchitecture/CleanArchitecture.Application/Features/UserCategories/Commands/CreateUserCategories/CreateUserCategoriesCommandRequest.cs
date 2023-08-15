using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.UserCategory.Commands.CreateUserCategories
{
    public class CreateUserCategoriesCommandRequest : IRequest<CreateUserCategoriesCommandResponse>
    {
        public string UserId { get; set; }

        public List<string> UserSkills { get; set; }
    }
}
