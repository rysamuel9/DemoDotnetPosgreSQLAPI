using AutoMapper;
using DemoPostgresAPI.Data;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;

namespace DemoPostgresAPI.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course CreateCourse(string courseCode, string courseName, string description, Guid categoryID);
        Course GetCourseById(Guid id);
    }

    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            return _mapper.Map<IEnumerable<Course>>(courses);
        }

        public Course CreateCourse(string courseCode, string courseName, string description, Guid categoryID)
        {
            var course = new Course
            {
                ROWID = Guid.NewGuid(),
                CourseCode = courseCode,
                CourseName = courseName,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CategoryID = categoryID
            };

            var category = _context.CourseCategories.FirstOrDefault(c => c.ROWID == categoryID);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return course;
        }

        public Course GetCourseById(Guid id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.ROWID == id);
            return course;
        }
    }
}
