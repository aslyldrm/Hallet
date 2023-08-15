using CleanArchitecture.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    
    public class ImageFile : BaseEntity

    {
        public string JobId { get; set; }
        public string JobImage { get; set; }


      
    }
}
