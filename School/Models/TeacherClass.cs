using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class TeacherClass
    {
        [Key]
        public int TeacherClassId { get; set; }

        [Required]
        [ForeignKey("Class")]
        public int FkClassId { get; set; }
        public Class? Class { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
