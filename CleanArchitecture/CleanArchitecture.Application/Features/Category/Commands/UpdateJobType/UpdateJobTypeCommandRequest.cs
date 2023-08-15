using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.JopType.Commands.UpdateJobType
{
    public class UpdateJobTypeCommandRequest : IRequest<UpdateJobTypeCommandResponse>
    {    
       // public string Id { get; set; }
        public string CategoryName { get; set; }
   


    }
}
