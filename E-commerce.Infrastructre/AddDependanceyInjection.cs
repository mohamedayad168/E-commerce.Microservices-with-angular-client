using E_commerce.Core.Repository_Contracts;
using E_commerce.Infrastructre.DbContext;
using E_commerce.Infrastructre.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Infrastructre
{
    public static class AddDependanceyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
