using System.ComponentModel.DataAnnotations;

namespace DemoPostgresAPI.Models
{
    public class Course
    {
        [Key]
        public Guid ROWID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
