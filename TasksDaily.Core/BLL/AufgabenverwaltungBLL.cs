using TasksDaily.Core.DAL;
using TasksDaily.Core.Data.DbModels;

namespace TasksDaily.Core.BLL
{
  public class AufgabenverwaltungBLL
  {
    private readonly IAufgabenverwaltungDataService aufgabenverwaltungDataService;

    public AufgabenverwaltungBLL(
      IAufgabenverwaltungDataService aufgabenverwaltungDataService
    )
    {
      this.aufgabenverwaltungDataService = aufgabenverwaltungDataService;
    }

    public async Task AddTaskItemAsync(Dto.TaskItemDto taskItemDto, Guid userId)
    {
      var task = new TaskItem
      {
        Title = taskItemDto.Title,
        Description = taskItemDto.Description,
        DueDate = taskItemDto.DueDate,
        Priority = taskItemDto.Priority,
        CategoryId = taskItemDto.CategoryId,
        IsArchived = false,
        UserId = userId


      };

      await aufgabenverwaltungDataService.AddTaskItemAsync(task);
    }
  }
}
