using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Account
{
    public class RefreshToken
    {
        public string Token { get; set; } = String.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}
