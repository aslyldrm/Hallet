using CleanArchitecture.Core.Entities.Common;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly HalletDbContext _context;

        

        public ReadRepository(HalletDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }
          
      
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();

            return query;


        }





        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {

            // => Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            //  => await Table.FindAsync(Guid.Parse(id));
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));


        }
        public async Task<List<T>> GetByCustomCriteriaAsync(string columnName, string value)
        {
            var tableName = _context.Model.FindEntityType(typeof(T)).GetTableName(); // Tablo adını almak için

            var query = _context.Set<T>().FromSqlRaw($"SELECT * FROM [{tableName}] WHERE [{columnName}] = @Value", new SqlParameter("@Value", value));

            return await query.ToListAsync();
        }


    }
}
