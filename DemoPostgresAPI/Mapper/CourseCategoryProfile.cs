using AutoMapper;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;

namespace DemoPostgresAPI.Mapper
{
    public class CourseCategoryProfile : Profile
    {
        public CourseCategoryProfile()
        {
            CreateMap<CourseCategory, CourseCategoryDto>();
        }
    }
}
