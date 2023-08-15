using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.DeleteJobDoerRequest
{
    public class DeleteJobDoerRequestCommandRequest : IRequest<DeleteJobDoerRequestCommandResponse>
    {
        public string JobId { get; set; }
        public string JobDoerUserId { get; set; }
    }
}
