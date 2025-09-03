using TasksDaily.Core.Data;

namespace TasksDaily.Core.BLL.Dto
{
  public class TaskItemDto
  {
    public int? Id { get; set; }

    public required string Title { get; set; }
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public PriorityLevel Priority { get; set; }

    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
  }
}
