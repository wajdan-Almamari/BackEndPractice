using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    internal class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enrollmentId { get; set; } //system auto-generated

        [ForeignKey(nameof(Student))]
        public int studentId { get; set; } //foreign key
        public Student student { get; set; }

        [ForeignKey(nameof(Course))]
        public int courseId { get; set; } //foreign key
        public Course course { get; set; }

        [Required]
        public DateTime enrollmentDate { get; set; } //user input

        [MaxLength(2)]
        public string? finalGrade { get; set; } //user input

        [Required]
        [MaxLength(20)]
        [DefaultValue("In Progress")]
        public string status { get; set; } //default value
    }
}