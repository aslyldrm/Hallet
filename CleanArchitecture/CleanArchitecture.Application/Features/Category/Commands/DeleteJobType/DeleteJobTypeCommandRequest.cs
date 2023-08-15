using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JopType.Commands.DeleteJobType
{
    public class DeleteJobTypeCommandRequest: IRequest<DeleteJobTypeCommandResponse>
    {
        public string CategoryName { get; set; }

    }
}
