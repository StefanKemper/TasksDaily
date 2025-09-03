using TasksDaily.Core.Data.DbModels;

namespace TasksDaily.Core.DAL
{
  public interface IAufgabenverwaltungDataService
  {
    Task AddTaskItemAsync(TaskItem taskItem);
    Task DeleteTaskItemAsync(int id);
    Task<List<TaskItem>> GetAllTaskItemsAsync();
    Task<TaskItem?> GetTaskItemByIdAsync(int id);
    Task UpdateTaskItemAsync(TaskItem taskItem);
  }
}