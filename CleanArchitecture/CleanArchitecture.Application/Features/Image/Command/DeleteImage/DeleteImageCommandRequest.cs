using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Image.Command.DeleteImage
{
    public class DeleteImageCommandRequest: IRequest<DeleteImageCommandResponse>
    {
        public string JobId { get; set; }
        public string ImageName { get; set; }
    }
}
