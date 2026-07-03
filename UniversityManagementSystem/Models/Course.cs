using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    [Index(nameof(courseCode), IsUnique = true)]
    internal class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; } //system auto-generated

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[0-9]+$")]
        public string courseCode { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; } //user input

        [Required]
        [Range(1, 6)]
        public int creditHours { get; set; } //user input

        [ForeignKey("department")]
        public int departmentId { get; set; } //foreign key
        public Department department { get; set; } //navigation property

        [ForeignKey("instructor")]
        public int? instructorId { get; set; } //foreign key
        public Instructor instructor { get; set; } //navigation property

        [Required]
        [MaxLength(20)]
        public string semesterOffered { get; set; } //user input
        public ICollection<Enrollment> Enrollments { get; set; } //navigation property
    }
}