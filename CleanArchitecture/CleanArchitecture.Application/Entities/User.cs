using CleanArchitecture.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Range(1.0, 5.0)]
        public double Rating { get; set; }
        public string Image { get; set; } 
        public string RefreshToken { get; set; } = string.Empty; 
        public DateTime Expires { get; set; }
        public int CompletedJobs { get; set; }
    }
}
