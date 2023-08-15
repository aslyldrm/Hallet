using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommandRequest : IRequest<DeleteJobCommandResponse>
    {
        public string Id { get; set; }
    }
}
