using DemoPostgresAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _courseCategoryService;

        public CourseCategoryController(ICourseCategoryService courseCategoryService)
        {
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public IActionResult GetAllCourseCategories()
        {
            var courseCategories = _courseCategoryService.GetAllCourseCategories();
            return Ok(courseCategories);
        }

        [HttpPost]
        public IActionResult CreateCourseCategory([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name is required.");
            }

            try
            {
                var courseCategory = _courseCategoryService.CreateCourseCategory(name);
                return CreatedAtAction(nameof(GetCourseCategoryById), new { id = courseCategory.ROWID }, courseCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the course category: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseCategoryById(Guid id)
        {
            var courseCategory = _courseCategoryService.GetCourseCategoryById(id);
            if (courseCategory == null)
            {
                return NotFound();
            }

            return Ok(courseCategory);
        }

        //[HttpGet]
        //public IActionResult GetAllCategoriesWithCourses()
        //{
        //    try
        //    {
        //        var categoriesWithCourses = _courseCategoryService.GetAllCategoriesWithCourses();
        //        return Ok(categoriesWithCourses);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred while retrieving categories with courses: {ex.Message}");
        //    }
        //}
    }
}
