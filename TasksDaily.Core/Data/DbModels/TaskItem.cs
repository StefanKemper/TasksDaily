namespace TasksDaily.Core.Data.DbModels
{
  public class TaskItem
  {
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public PriorityLevel Priority { get; set; }

    public string? ReferenceLink { get; set; }

    public bool IsArchived { get; set; } = false;

    // FK und Navigation
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? TimeSlotId { get; set; }
    //public TimeSlot? TimeSlot { get; set; }
  }
}
