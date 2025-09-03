using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace TasksDaily.Api
{
  public static class ApiServiceExtensions
  {
    public static IServiceCollection AddOpenApiDoc(this IServiceCollection services)
    {
      // Note: This NSwag registration isn't used by /openapi/v1.json.
      // You may remove it if you don't use NSwag endpoints.
      services.AddOpenApiDocument();

      services.AddOpenApi(options =>
      {
        options.AddDocumentTransformer((document, context, ct) =>
        {
          document.Components ??= new OpenApiComponents();
          document.Components.SecuritySchemes ??= new Dictionary<string, OpenApiSecurityScheme>();

          document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
          {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "JWT Bearer authorization header using the Bearer scheme."
          };

          // Optional: globaler Default (kann bleiben)
          document.SecurityRequirements ??= new List<OpenApiSecurityRequirement>();
          document.SecurityRequirements.Add(new OpenApiSecurityRequirement
          {
            [new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            }] = Array.Empty<string>()
          });

          return Task.CompletedTask;
        });
      });

      return services;
    }

    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
      options.Authority = "https://auth.stefan-kemper.de/realms/Apps";
      options.Audience = "apps-api";
      options.RequireHttpsMetadata = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateAudience = true,
        RoleClaimType = "roles"
      };
    });

      services.AddAuthorization();
      services.AddScoped<IClaimsTransformation, KeycloakRolesClaimsTransformation>();
      return services;
    }
  }
}
