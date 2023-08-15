using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.UserCategories.Queries.GetAllUserCategories
{
    public class GetByIdUserCategoriesResponse
    {

        // public string UserId { get; set; }
        // public string CategoryName { get; set; }
        public List<string> CategoryNames { get; set; } = new List<string>();
    }
}
