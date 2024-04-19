using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public required string TeacherName { get; set; }

        public ICollection<TeacherCourse>? Courses { get; set; }
        public ICollection<TeacherClass>? MentorClasses { get; set; }
    }
}
