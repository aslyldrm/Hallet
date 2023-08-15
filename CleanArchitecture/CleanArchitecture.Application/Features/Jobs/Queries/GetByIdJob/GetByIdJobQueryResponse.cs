using CleanArchitecture.Core.Entities;
//using CleanArchitecture.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Jobs.Queries.GetByIdJob
{
    public class GetByIdJobQueryResponse
    {
        public string Title { get; set; }
        public string JobType { get; set; }

        public string Status { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        //image kısmının çoklu olması,filtreleme
 
        public DateTime CompletedTime { get; set; }

        public string Location { get; set; }
        public string City { get; set; }
        public string OwnerId { get; set; }
        public string JobDoerId { get; set; }
        public int JobPosterRating { get; set; }

        public string  JobPosterRequestId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
