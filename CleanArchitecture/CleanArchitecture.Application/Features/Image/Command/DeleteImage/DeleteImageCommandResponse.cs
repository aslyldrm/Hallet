using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Image.Command.DeleteImage
{
    public class DeleteImageCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
