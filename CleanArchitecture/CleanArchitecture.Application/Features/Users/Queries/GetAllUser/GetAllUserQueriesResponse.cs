using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueriesResponse
    {
        public List<User> AllUser { get; set; } = new List<User>();
    }
}
