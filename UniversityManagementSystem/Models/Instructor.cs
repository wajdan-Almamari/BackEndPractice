using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagementSystem.Models
{
    internal class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instructorId { get; set; } //auto-generated

        [Required]
        [MaxLength(100)]
        public string instructorName { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string instructorEmail { get; set; }//user input

        [MaxLength(20)]
        public string? instructorOfficeNum { get; set; } //? Optional (nullable values enabled)

        [Required]
        public DateTime instructorHireDate { get; set; }//user input

        [Required]
        //int.MaxValue = largest possible value an int can store in C#.
        //typeof(decimal) = Get the type information for the decimal type.
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Salary must be greater than 0.")]
        public decimal instructorSalary { get; set; }//user input

        [Required]
        [MaxLength(50)]
        public string instructorAcademicTitle { get; set; }//user input
    }
}