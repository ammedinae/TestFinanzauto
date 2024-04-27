using Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebService.Modules.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //APPSETTNGNS
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var secret = Encrypt.EncriptarSHA512(configuration.GetSection("NameSite").Value! + "OutS0urc1ng2023SdSWcB");
            var key = Encoding.ASCII.GetBytes(secret);
            var issuer = appSettings!.Issuer;
            var Audience = appSettings.Audience;

            //AUTENTICACION TOKEN
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }
                );

            return services;
        }
    }
}
