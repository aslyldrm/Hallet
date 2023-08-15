using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Image.Command.UpdateImage
{
    public class UpdateImageCommandRequest : IRequest<UpdateImageCommandResponse>
    {
        public string JobId { get; set; }
        public string ImageName { get; set; }
        public string NewImageName { get; set; }
    }
}
