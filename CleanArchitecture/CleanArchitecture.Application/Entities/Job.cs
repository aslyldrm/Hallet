using CleanArchitecture.Core.Entities.Common;
//using CleanArchitecture.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
   
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public string DoerId { get; set; }
        public string JobType { get; set; }
        public string JobPosterRequestId { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
   

        public int JobPosterRating { get; set; }
        //public int JobDoerRating { get; set; }
        public float Price { get; set; }

        public DateTime CompletedTime { get; set; }

      
      
  

      


    }
}
