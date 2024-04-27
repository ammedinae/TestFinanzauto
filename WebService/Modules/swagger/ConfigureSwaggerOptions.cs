using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Asp.Versioning.ApiExplorer;

namespace WebService.Modules.injection
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;

        public static string _Title { get; set; } = null!;

        public static string _Description { get; set; } = null!;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _Title = configuration.GetSection("NameSite").Value!;
            _Description = configuration.GetSection("Description").Value!;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }
        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = _Title,
                Description = _Description,
                Contact = new OpenApiContact()
                {
                    Name = "TestFinanzauto"
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta version de la API ha quedado obsoleta.";
            }

            return info;
        }
    }
}
