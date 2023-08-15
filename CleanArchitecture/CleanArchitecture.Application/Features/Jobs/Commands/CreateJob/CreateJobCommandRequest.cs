using CleanArchitecture.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandRequest : IRequest<CreateJobCommandResponse>
    {
        public string Title { get; set; }
        public string JobType { get; set; }
        public string Description { get; set; }
        //public List<string> Images { get; set; }
        public float Price { get; set; }

        public string OwnerId { get; set; }

        public string Location { get; set; }
        public string City { get; set; }

    }
}
