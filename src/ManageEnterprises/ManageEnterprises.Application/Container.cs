using ManageEnterprises.Infrastructure.DBConfiguration;
using ManageEnterprises.Infrastructure.DBConfiguration.EFCore;
using ManageEnterprises.Infrastructure.Repositories;
using ManageEnterprises.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ManageEnterprises.Application
{
    public static class Container
    {
        public static void AddModules(this IServiceCollection services) 
        {
            AddContext(services);
            AddRepositories(services);
            AddMediator(services);
        }

        private static void AddMediator(IServiceCollection services)
            => services.AddMediatR(AppDomain.CurrentDomain.Load("ManageEnterprises.Application"));

        private static void AddContext(IServiceCollection services)
            => services.AddDbContext<ApplicationContext>(options => {
                options.UseSqlServer(DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection"));
            });

        private static void AddRepositories(IServiceCollection services)
        { 
            services.AddScoped<IEnterpriseRepo, EnterpriseRepo>(); 
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}
