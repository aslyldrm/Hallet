using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.CreateJobDoerRequest
{
    public class CreateJobDoerRequestCommandRequest :IRequest<CreateJobDoerRequestCommandResponse>
    {
        public string JobId { get; set; }
        public string JobDoerUserId { get; set; }
    }
}
