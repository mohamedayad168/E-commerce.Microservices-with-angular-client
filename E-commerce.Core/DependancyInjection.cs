using E_commerce.Core.Service_Contracts;
using E_commerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_commerce.Core
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
