using CleanArchitecture.Core.Abstractions.Storage;
//using CleanArchitecture.Core.Entities.Identity;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Repositories.Image;
using CleanArchitecture.Core.Interfaces.Services.JobFilterService;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Enums;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Repositories.Image;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Infrastructure.Services.JobFilterService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            /*
            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<HalletDbContext>();
            */
            //Ioc container bu kısım
            services.AddDbContext<HalletDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("sqlConnection")), ServiceLifetime.Scoped);

            services.AddScoped<IJobReadRepository, JobReadRepository>();
            services.AddScoped<IJobWriteRepository, JobWriteRepository>();

            services.AddScoped<IWriteImageRepository, ImageWriteRepository>();
            services.AddScoped<IReadImageRepository, ImageReadRepository>();

            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IUserWriteCategoryRepository, UserWriteCategoryRepository>();
            services.AddScoped<IUserReadCategoryRepository, UserReadCategoryRepository>();

            services.AddScoped<IJobDoerRequestReadRepository, JobDoerRequestReadRepository>();
            services.AddScoped<IJobDoerRequestWriteRepository, JobDoerRequestWriteRepository>();

            services.AddScoped<IJobRejectedRequestReadRepository, JobRejectedRequestReadRepository>();
            services.AddScoped<IJobRejectedRequestWriteRepository, JobRejectedRequestWriteRepository>();

            services.AddScoped<IJobFilterReadRepository, JobFilterReadService>();



            //services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            // services.AddScoped<Core.Interfaces.Repositories.IJobImageFileWriteRepository, JobImageFileWriteRepository>();
            // services.AddScoped<IJobImageFileReadRepository, JobImageFileReadRepository>();

            //services.AddScoped<IStorageService,StorageService>();



        }
        /*
        public static void AddStorage<T>(this IServiceCollection serviceCollection) 
            where T: Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage,T>();
        }

        public static void AddStorage(this IServiceCollection serviceCollection,StorageTypes storageType)
    
        {

            switch (storageType)
            {
                case StorageTypes.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageTypes.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageTypes.AWS:
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
           
        }
        */

    }
   
}
