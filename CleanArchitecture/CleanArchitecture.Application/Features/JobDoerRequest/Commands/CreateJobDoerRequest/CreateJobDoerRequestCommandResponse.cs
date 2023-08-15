using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.CreateJobDoerRequest
{
    public class CreateJobDoerRequestCommandResponse
    {
        public string JobId { get; set; }
        public List<string> JobDoerUserId { get; set; }
    }
}
