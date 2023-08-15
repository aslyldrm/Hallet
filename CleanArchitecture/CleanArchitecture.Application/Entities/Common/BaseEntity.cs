using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        virtual public DateTime CreatedDate { get; set; } 
    }
}
