namespace WebService.Modules.HealthChecks
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DBConectionString"), tags: new[] { "DATABASE" });

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }
    }
}
