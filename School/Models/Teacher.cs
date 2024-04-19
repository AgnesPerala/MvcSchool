using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public required string TeacherName { get; set; }

        public ICollection<TeacherCourse>? TeacherCourses { get; set; }
        public ICollection<TeacherClass>? TeacherClasses { get; set; }
    }
}
