using AutoMapper;
using TaskManagement.Core.Entities;
using TaskManagement.Services.DTOs.TaskItem;

namespace TaskManagement.Services.Map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem, TaskItemDTO>();
            CreateMap<TaskItemDTO, TaskItem>();

        }
    }
}
