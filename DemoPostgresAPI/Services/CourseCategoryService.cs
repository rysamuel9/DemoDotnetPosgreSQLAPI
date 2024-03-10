using AutoMapper;
using DemoPostgresAPI.Data;
using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;

namespace DemoPostgresAPI.Services
{
    public interface ICourseCategoryService
    {
        IEnumerable<CourseCategory> GetAllCourseCategories();
        CourseCategory CreateCourseCategory(string name);
        CourseCategoryDto GetCourseCategoryById(Guid id);
        //IEnumerable<CourseCategory> GetAllCategoriesWithCourses();
    }

    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseCategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CourseCategory> GetAllCourseCategories()
        {
            return _context.CourseCategories.ToList();
        }

        public CourseCategory CreateCourseCategory(string name)
        {
            var courseCategory = new CourseCategory
            {
                ROWID = Guid.NewGuid(),
                Name = name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.CourseCategories.Add(courseCategory);
            _context.SaveChanges();

            return courseCategory;
        }

        public CourseCategoryDto GetCourseCategoryById(Guid id)
        {
            var courseCategory = _context.CourseCategories.FirstOrDefault(c => c.ROWID == id);
            return _mapper.Map<CourseCategoryDto>(courseCategory);
        }


        //public IEnumerable<CourseCategory> GetAllCategoriesWithCourses()
        //{
        //    var categories = _context.CourseCategories.ToList();

        //    foreach (var category in categories)
        //    {
        //        category.Courses = _context.Courses.Where(c => c.CategoryID == category.ROWID).ToList();
        //    }

        //    return categories;
        //}
    }
}
