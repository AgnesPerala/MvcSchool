using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public required string CourseName { get; set; }
        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }

    }
}
