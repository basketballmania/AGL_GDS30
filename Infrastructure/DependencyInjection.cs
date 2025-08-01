using AGL.Api.Infrastructure.Data;
using AGL.Api.Infrastructure.Repository;
using AGL.Api.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AGL.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL 연결 (Shoppingdb2)
            services.AddDbContext<ShoppingDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                       .UseNpgsql(configuration["ConnectionStrings:Shoppingdb2.Application.ConnectionString"],
                       npgsqlOptionsAction: sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(typeof(ShoppingDbContext).GetTypeInfo().Assembly.FullName);
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                       });
            }, ServiceLifetime.Scoped);

            // MSSQL 연결 (CMS)
            //services.AddDbContext<CmsDbContext>(options =>
            //{
            //    options.UseLazyLoadingProxies()
            //           .UseSqlServer(configuration["CMS.Application.ConnectionString"],
            //           sqlServerOptionsAction: sqlOptions =>
            //           {
            //               sqlOptions.MigrationsAssembly(typeof(CmsDbContext).GetTypeInfo().Assembly.FullName);
            //               sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30));
            //           });
            //}, ServiceLifetime.Scoped);
            services.AddDbContextPool<CmsDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(configuration["ConnectionStrings:CMS.Application.ConnectionString"],
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.MigrationsAssembly(typeof(CmsDbContext).GetTypeInfo().Assembly.FullName);
                              sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                          });
            });

            // Repository 등록
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IGolfFieldRepository, GolfFieldRepository>();

            return services;
        }
    }
}
