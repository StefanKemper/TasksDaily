using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Reflection;
using TasksDaily.Api;
using TasksDaily.Core.Data;


internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    var config = builder.Configuration;

    // Add services to the container.

    services.AddControllers();
    services.AddOpenApiDoc();

    services.AddDbContext<TasksDailyDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TasksDailyDb")));

    services.AddAuthServices(config);

    services.AddApiVersioning(
      options =>
      {
        options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
      })
    .AddMvc();


    var coreAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Single(a => a.Name != null && a.Name.Contains("TasksDaily.Core"));
    builder.Services.AddAutoMapper(cfg => { }, Assembly.Load(coreAssembly));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
      app.MapScalarApiReference(options =>
      {
        options.Title = "TasksDaily API";
        options.Authentication = new ScalarAuthenticationOptions
        {
          PreferredSecuritySchemes = new List<string> { "Bearer" }
        };
      });
      app.UseStaticFiles();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors();

    app.Run();
  }
}