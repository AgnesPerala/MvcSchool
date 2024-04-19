using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class TeacherCourse
    {
        [Key]
        public int TeacherCourseId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course? Course { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
