using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
        public StudentClass? StudentClass { get; set; }
    }
}
