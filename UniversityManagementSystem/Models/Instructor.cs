using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    [Index(nameof(email), IsUnique = true)]
    internal class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instructorId { get; set; } //system auto-generated

        [Required]
        [MaxLength(100)]
        public string fullName { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string email { get; set; } //user input

        [MaxLength(20)]
        public string? officeNumber { get; set; } //user input

        [Required]
        public DateTime hireDate { get; set; } //user input

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal salary { get; set; } //user input

        [Required]
        [MaxLength(50)]
        public string academicTitle { get; set; } //user input
        public virtual ICollection<Course> Courses { get; set; } //navigation property
        public virtual Department? HeadDepartment { get; set; } //navigation property
    }
}