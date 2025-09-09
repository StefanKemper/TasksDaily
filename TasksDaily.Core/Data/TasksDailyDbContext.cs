using Microsoft.EntityFrameworkCore;
using TasksDaily.Core.Data.DbModels;

namespace TasksDaily.Core.Data
{
  public class TasksDailyDbContext : DbContext
  {
    public TasksDailyDbContext(DbContextOptions<TasksDailyDbContext> options)
        : base(options)
    {
    }


    // DbSets für alle DbModels im Ordner "DbModels"
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Optional: weitere Konfigurationen für die DbModels
    }
  }
}
