using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public ICollection<StudentCourse>? Enrollments { get; set; }
        public StudentClass? Class { get; set; }
    }
}
