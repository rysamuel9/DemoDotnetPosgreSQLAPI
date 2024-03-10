using AutoMapper;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;

namespace DemoPostgresAPI.Mapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseCreateDto>();
        }
    }
}
