using CleanArchitecture.Core.Entities.Common;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly HalletDbContext _context;

        public WriteRepository(HalletDbContext context)
        {
            _context = context;
        }

        public Microsoft.EntityFrameworkCore.DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model) {

            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return true;
        }
   

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
           await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    
            return Remove(model);
        }

        public bool Remove(T model)
        {
            
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }


        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        
            => await _context.SaveChangesAsync();

        public async Task<int> DeleteByCustomCriteriaAsync(string jobId, string jobDoerId,string nameOfColumnId,string nameOfColumn)
        {
            var tableName = _context.Model.FindEntityType(typeof(T)).GetTableName(); // Tablo adını almak için

            var query = _context.Database.ExecuteSqlRaw($"DELETE FROM [{tableName}] WHERE [{nameOfColumnId}] = @JobId AND [{nameOfColumn}] = @JobDoerRequestUserId",
                new SqlParameter("@JobId", jobId),
                new SqlParameter("@JobDoerRequestUserId", jobDoerId));

            return  query;
        }


    }

}
