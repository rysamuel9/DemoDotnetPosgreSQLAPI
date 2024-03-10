namespace DemoPostgresAPI.DTO
{
    public class CourseCreateDto
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
    }
}
