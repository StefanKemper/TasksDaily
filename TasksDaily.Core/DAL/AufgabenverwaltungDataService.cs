using Microsoft.EntityFrameworkCore;
using TasksDaily.Core.Data;

namespace TasksDaily.Core.DAL
{
  public class AufgabenverwaltungDataService : IAufgabenverwaltungDataService
  {
    private readonly TasksDailyDbContext tasksDailyDbContext;

    public AufgabenverwaltungDataService(TasksDailyDbContext tasksDailyDbContext)
    {
      this.tasksDailyDbContext = tasksDailyDbContext;
    }

    public async Task AddTaskItemAsync(Data.DbModels.TaskItem taskItem)
    {
      await tasksDailyDbContext.TaskItems.AddAsync(taskItem);
      await tasksDailyDbContext.SaveChangesAsync();
    }

    public async Task<List<Data.DbModels.TaskItem>> GetAllTaskItemsAsync()
    {
      return await tasksDailyDbContext.TaskItems.ToListAsync();
    }

    public async Task<Data.DbModels.TaskItem?> GetTaskItemByIdAsync(int id)
    {
      return await tasksDailyDbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateTaskItemAsync(Data.DbModels.TaskItem taskItem)
    {
      tasksDailyDbContext.TaskItems.Update(taskItem);
      await tasksDailyDbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskItemAsync(int id)
    {
      var taskItem = await tasksDailyDbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
      if (taskItem != null)
      {
        tasksDailyDbContext.TaskItems.Remove(taskItem);
        await tasksDailyDbContext.SaveChangesAsync();
      }
    }
  }
}
