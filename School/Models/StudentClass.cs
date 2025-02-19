﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        [ForeignKey("Class")]
        public int FkClassId { get; set; }
        public Class? Class { get; set; }
    }
}
