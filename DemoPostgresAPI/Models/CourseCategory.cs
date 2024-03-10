using System.ComponentModel.DataAnnotations;

namespace DemoPostgresAPI.Models
{
    public class CourseCategory
    {
        [Key]
        public Guid ROWID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Course> Courses { get; set; }
    }
}
