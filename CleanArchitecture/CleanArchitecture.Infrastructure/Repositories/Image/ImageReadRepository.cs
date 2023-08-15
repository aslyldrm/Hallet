using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories.Image;
using CleanArchitecture.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories.Image
{
    public class ImageReadRepository : ReadRepository<ImageFile>, IReadImageRepository
    {
        public ImageReadRepository(HalletDbContext context) : base(context)
        {
        }
    }
}
