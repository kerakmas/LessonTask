using AutoMapper;
using LessonTask.Domain.Entities;
using LessonTask.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserResultDto>().ReverseMap();
            CreateMap<User, UserCreationDto>().ReverseMap();
        }
    }
}
