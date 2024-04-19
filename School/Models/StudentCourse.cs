using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace School.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }

    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }

        [EnumDataType(typeof(Grade))]
        public Grade? Grade { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public Course? Course { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public Student? Student { get; set; }
    }
}