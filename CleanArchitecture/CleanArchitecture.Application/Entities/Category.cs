using CleanArchitecture.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanArchitecture.Core.Entities
{
  
    public class Category : BaseEntity
    {
        // public string JobId { get; set; }

        [Column("TypeName")] // Mevcut sütun adını belirtiyoruz
        public string CategoryName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedDate { get; set; }

  
        public Guid Id { get; set; }

    }
}
