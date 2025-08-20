using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TasksDaily.Core.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
services.AddOpenApiDocument();
services.AddOpenApi();
services.AddDbContext<TasksDailyDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("TasksDailyDb")));

builder.Services.AddApiVersioning(
  options =>
  {
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1,0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
  })
.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference(options =>
  {
    options.Title = "Meine API";
  });
  app.UseStaticFiles();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();
