using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IJobDoerRequestWriteRepository : IWriteRepository<JobDoerRequest>
    {
        public void DeleteAndSaveData(string jobDoerRequestUserId);
    }
}
