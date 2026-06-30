using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } // User Input

        [MaxLength(20)]
        public string? PhoneNumber { get; set; } // User Input

        [Required]
        public DateTime DateOfBirth { get; set; } // User Input

        [Required]
        [Range(2000, 2030)]
        public int EnrollmentYear { get; set; } // User Input

        [Range(0.0, 4.0)]
        public decimal GPA { get; set; } = 0.0m; // Default Value

    }
}

