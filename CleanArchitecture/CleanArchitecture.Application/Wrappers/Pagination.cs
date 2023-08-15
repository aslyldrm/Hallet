using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Wrappers
{
    public class Pagination
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
}
}
