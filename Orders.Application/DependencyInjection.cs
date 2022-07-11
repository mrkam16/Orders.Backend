using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Orders.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
