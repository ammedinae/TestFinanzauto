using Business.BLL;
using Business.BLL.BaseBLL;
using Business.BLL.Login;
using Business.Interfaces;
using Business.Interfaces.BaseBLL;
using Business.Interfaces.Login;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseBLL<,,>), typeof(BaseBLL<,,>));
            services.AddScoped<ILoginBLL, LoginBLL>();
            services.AddScoped<IStudentBLL, StudentBLL>();
            services.AddDataServices(configuration);
            return services;
        }
    }
}
