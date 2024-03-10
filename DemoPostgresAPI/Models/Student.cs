using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoPostgresAPI.Models
{
    public class Student
    {
        [Key]
        public string ROWID { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
