using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Image.Command.CreateImages
{
    public class CreateImageCommandRequest :  IRequest<CreateImageCommandResponse>
    {
        public string JobId { get; set; }
        public List<string> JobImages { get; set; }

    }
}
