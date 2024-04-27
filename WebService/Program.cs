using Business;
using HealthChecks.UI.Client;
using WatchDog;
using WebService.Modules.Authentication;
using WebService.Modules.HealthChecks;
using WebService.Modules.injection;
using WebService.Modules.Mapper;
using Asp.Versioning.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
// AutoMapper
builder.Services.AddMapper();

builder.Services.AddVersioning();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddHealthCheck(builder.Configuration);

//Authentication
builder.Services.AddAuthenticationExtensions(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebService API");
    //c.RoutePrefix = string.Empty;
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
    {
        ApiVersionDescription? description = provider.ApiVersionDescriptions[i];
        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        c.RoutePrefix = string.Empty;
    }
});
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseEndpoints(_ => { });

app.Run();
