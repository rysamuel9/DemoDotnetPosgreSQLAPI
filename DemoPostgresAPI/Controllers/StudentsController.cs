using DemoPostgresAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPostgresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            var student = _studentService.CreateStudent(name);
            return CreatedAtAction(nameof(GetStudent), new { id = student.ROWID }, student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("search")]
        public IActionResult SearchStudents([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty.");
            }

            var students = _studentService.SearchStudentsByName(name);
            return Ok(students);
        }
    }
}

