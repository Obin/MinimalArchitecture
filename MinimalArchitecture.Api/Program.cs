using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinimalArchitecture.Api.Middlewares;
using MinimalArchitecture.Application;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinimalArchitecture.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            });

            webApplicationBuilder.Services.AddApplication();

            webApplicationBuilder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(_ => true);
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });

            webApplicationBuilder.Services.AddOpenApi();

            var webApplication = webApplicationBuilder.Build();

            webApplication.UseMiddleware<ExceptionMiddleware>();

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.MapOpenApi();
            }

            webApplication.UseCors();

            RoutingAggregator.RegisterRoutings(webApplication);

            webApplication.Run();
        }
    }
}