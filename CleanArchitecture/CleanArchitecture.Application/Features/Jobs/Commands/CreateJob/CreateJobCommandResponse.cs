using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandResponse 
    {
        public string JobId { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
