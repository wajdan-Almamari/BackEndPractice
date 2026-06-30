using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagementSystem.Models
{
    internal class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; } //system auto-generated

        [Required]
        [MaxLength(100)]
        public string studentName { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string studentEmail { get; set; } //user input

        [MaxLength(20)]
        public string? studentPhoneNum { get; set; }//user input

        [Required]
        public DateTime studentBirthDate { get; set; }//user input

        [Required]
        [Range(2000, 2030)]
        public int studentEnrollmentYear { get; set; }//user input

        [Range(0.0, 4.0)]
        [DefaultValue(0.0)]
        public decimal studentGpa { get; set; }//default value

    }
}