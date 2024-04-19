using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace School.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [EnumDataType(typeof(Grade))]
        public Grade? Grade { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course? Courses { get; set; }

        [ForeignKey("Student")]
        public int FkStudentId { get; set; }

        public virtual Student? Student { get; set; }
    }
}