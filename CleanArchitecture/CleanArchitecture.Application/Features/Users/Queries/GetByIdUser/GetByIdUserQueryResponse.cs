using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
       // public string Location { get; set; }
       
        public int CompletedJobs { get; set; }

        virtual public DateTime CreatedDate { get; set; }

       
    }
}
