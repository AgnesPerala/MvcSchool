using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public required string ClassName { get; set; }

        public ICollection<StudentClass>? Students { get; set; }
        public TeacherClass? Mentor { get; set; }
    }
}
