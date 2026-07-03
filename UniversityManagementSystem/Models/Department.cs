using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    [Index(nameof(departmentName), IsUnique = true)]
    internal class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; } //system auto-generated

        [Required]
        [MaxLength(100)]
        public string departmentName { get; set; } //user input

        [MaxLength(50)]
        public string? building { get; set; } //user input

        [Required]
        //[Range(0, double.MaxValue)]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal budget { get; set; } //user input

        [ForeignKey("HeadInstructor")]
        public int? headInstructorId { get; set; } //foreign key
        public Instructor? HeadInstructor { get; set; } //navigation property
        public ICollection<Course> Courses { get; set; } //navigation property
    }
}