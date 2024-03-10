using AutoMapper;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;

namespace DemoPostgresAPI.Mapper
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
        }
    }
}
