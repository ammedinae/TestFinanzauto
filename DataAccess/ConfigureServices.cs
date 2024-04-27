using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebserviceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConectionString")));

            return services;
        }
    }
}
