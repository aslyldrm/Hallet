using CleanArchitecture.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JopType.Commands.CreateJobType
{
    public class CreateJobTypeCommandRequest : IRequest<CreateJobTypeCommandResponse>
    {
        public string TypeName { get; set; }
       
    }
}
