using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Exceptions
{
    public class UserCreatedFailedExceptions : Exception
    {
        public UserCreatedFailedExceptions() { }

        public UserCreatedFailedExceptions(string message) : base(message)
        {
        }

        public UserCreatedFailedExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }



    }
}
