using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassId { get; set; }
        public string Title { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
