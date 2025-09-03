using AutoMapper;
using TasksDaily.Core.Data.DbModels;

namespace TasksDaily.Core.BLL.Dto.MapperProfiles
{
  public class TaskItemProfile : Profile
  {
    public TaskItemProfile() 
    {
      CreateMap<TaskItem, Dto.TaskItemDto>()
        .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
    }
  }
}
