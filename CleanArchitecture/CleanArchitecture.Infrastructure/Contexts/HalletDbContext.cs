using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Common;
//using CleanArchitecture.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Contexts
{                                 //DbContext
    public class HalletDbContext : DbContext // IdentityDbContext<AppUser>
    {
        public HalletDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<JobRejectedRequest> JobRejectedRequest { get; set; }

        public DbSet<JobDoerRequest> JobDoerRequest { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow

                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Ignore(e => e.CreatedDate)
                .HasKey(e => e.Id)
            
                ;
            modelBuilder.Entity<UserCategory>() .HasKey(e => e.Id);
       
           

            modelBuilder.Entity<JobRejectedRequest>()
        
              .Ignore(e => e.CreatedDate);


            modelBuilder.Entity<JobDoerRequest>()
     
              .Ignore(e => e.CreatedDate);

            modelBuilder.Entity<UserCategory>()

              .Ignore(e => e.CreatedDate);

        }
        /*
        base.OnModelCreating(builder);

            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();


            builder.Entity<AppUser>()
            .HasMany(u => u.Jobs)
            .WithOne(j => j.User)
            .HasForeignKey(j => j.Id);

        }
        */

    }
}
