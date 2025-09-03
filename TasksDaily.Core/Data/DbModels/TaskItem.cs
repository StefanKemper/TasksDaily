namespace TasksDaily.Core.Data.DbModels
{
  public class TaskItem
  {
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public PriorityLevel Priority { get; set; }

    public bool IsArchived { get; set; } = false;

    // FK und Navigation
    public int CategoryId { get; set; }
    public required Category Category { get; set; }

    public int UserId { get; set; }
    public required User User { get; set; }

    //public string? ReferenceLink { get; set; }
    //public int? TimeSlotId { get; set; }
    //public TimeSlot? TimeSlot { get; set; }
  }
}
