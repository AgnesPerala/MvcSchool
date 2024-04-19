using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public required string ClassName { get; set; }

        public ICollection<StudentClass>? StudentClasses { get; set; }
        public TeacherClass? TeacherClass { get; set; }
    }
}
