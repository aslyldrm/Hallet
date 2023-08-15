using CleanArchitecture.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CleanArchitecture.Core.Entities
{

    public class JobDoerRequest : BaseEntity
    {
        public string JobId { get; set; }
        public string JobDoerRequestUserId { get; set; }
      
     
        [IgnoreDataMember]
        public DateTime CreatedDate { get; set; }
    }
}
