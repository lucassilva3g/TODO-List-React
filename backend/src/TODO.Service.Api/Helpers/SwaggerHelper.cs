using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Todo.Service.Api.Helpers;

public static class SwaggerHelper
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            AddSwaggerFrontDoc(s);

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

        });
    }

    private static void AddSwaggerFrontDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("api", GetOpenApiInfo("api"));
    }

    private static OpenApiInfo GetOpenApiInfo(string version, string title = "Todo Service - API")
    {
        return new OpenApiInfo
        {
            Title = title,
            Version = version,
            Contact = new OpenApiContact
            {
                Name = "Todo Service",
            }
        };
    }

    public static void CustomUseSwagger(this IApplicationBuilder app)
    {

        app.UseSwagger();

        app.UseSwaggerUI(c => { AddSwaggerUIEndpoints(c); });

    }

    private static void AddSwaggerUIEndpoints(SwaggerUIOptions options)
    {
        options.SwaggerEndpoint($"/swagger/api/swagger.json", "Todo Service - API");
    }
}
