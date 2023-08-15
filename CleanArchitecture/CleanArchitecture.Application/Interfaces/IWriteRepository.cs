using CleanArchitecture.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IWriteRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
        Task<int> DeleteByCustomCriteriaAsync(string jobId, string jobDoerId, string nameOfColumnId, string nameOfColumn);


    }
}
