using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CleanArchitecture.Core.Features.Users.Command.LoginUser
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpires { get; set; }

    }
}
