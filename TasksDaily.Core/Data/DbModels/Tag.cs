namespace TasksDaily.Core.Data.DbModels
{
  public class Tag
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; } = null;

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    // Navigation zu TaskItems
    public ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
  }
}
