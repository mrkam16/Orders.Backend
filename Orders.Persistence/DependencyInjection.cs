using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Interfaces;

namespace Orders.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //var connection = configuration.GetConnectionString("OrdersDBConnection");

            services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("OrdersDBConnection"));    
            // options.UseSqlServer(connection)
            
            services.AddScoped<IOrderDbContext>(provider => provider.GetService<OrderDbContext>());

            return services;
        }
    }
}
