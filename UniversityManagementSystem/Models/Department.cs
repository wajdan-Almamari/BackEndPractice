using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UniversityManagementSystem.Models
{
    internal class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; } //auto-generated

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; } //user input

        [MaxLength(50)]
        public string? DepartmentBuildig { get; set; }//user input

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Budget must be greater than 0.")]
        public decimal DepartmentBudget { get; set; }//user input

        [ForeignKey(nameof(Instructor))]
        public string? HeadInstructorId { get; set; } //foreign key (from list)

        public Instructor Instructor { get; set; }
    }
}