using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TasksDaily.Core.DAL;

namespace TasksDaily.Core
{
  public static class CoreServiceExtensions
  {
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
      services.AddScoped<IAufgabenverwaltungDataService, AufgabenverwaltungDataService>();

      services.AddScoped<IValidator<BLL.Dto.TaskItemDto>, BLL.Validators.TaskItemDtoValidator>();

      return services;
    }
  }
}
