using CleanArchitecture.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using CleanArchitecture.Core.Entities.Common;


namespace CleanArchitecture.Core.Entities
{

    public class UserCategory : BaseEntity
    {

  
     
        [IgnoreDataMember]
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public string UserCategoryName { get; set; }
    }
}
