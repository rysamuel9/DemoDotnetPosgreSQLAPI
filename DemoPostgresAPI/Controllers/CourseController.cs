using DemoPostgresAPI.DTO;
using DemoPostgresAPI.Models;
using DemoPostgresAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult CreateCourse(string courseCode, string courseName, string description, Guid categoryID)
        {
            try
            {
                var createdCourse = _courseService.CreateCourse(courseCode, courseName, description, categoryID);
                return CreatedAtAction(nameof(GetCourseById), new { id = createdCourse.ROWID }, createdCourse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the course: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCourseById(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}
