using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JobDoerRequest.Commands.DeleteJobDoerRequest
{
    public class DeleteJobDoerRequestCommandResponse
    {
        //public List<Entities.JobDoerRequest> RemainingJobDoerRequests { get;  set; }
        public string Message { get; set; }

        public bool Success { get; set; }
    }
}
