using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagementSystem.Models
{
    internal class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enrollmentId { get; set; }

        [ForeignKey(nameof(Student))]
        public int studentId { get; set; }
        public Student student { get; set; }

        [ForeignKey(nameof(Course))]
        public int courseId { get; set; }
        public Course course { get; set; }

        [Required]
        public DateTime enrollmentDate { get; set; }

        [MaxLength(2)]
        [RegularExpression(@"^(A|A\+|A\-|B|B\+|B\-|C|C\-|C\+|D|D\-|D\+|F)$")]
        public string? finalGrade { get; set; }

        [Required]
        [MaxLength(20)]
        [DefaultValue("In Progress")]
        public string status { get; set; }

    }
}