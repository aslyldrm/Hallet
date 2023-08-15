using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Filter.FilteringJobs
{
    public class JobFilterResponse
    {
        public string Cities { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Categories { get; set; }
    }
}
