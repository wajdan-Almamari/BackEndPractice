using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public string courseCode { get; set; } //system auto-generated

        [Required]
        [MaxLength(150)]
        public string courseTitle { get; set; } //user input

        [Required]
        [Range(1, 6)]
        public int courseCreditHours { get; set; }//user input

        [ForeignKey(nameof(Department))] //to avoid renaming issue
        //without ? means not null
        public int DepartmentId { get; set; } //foreign key of the department (from list)
        public Department department { get; set; }

        [ForeignKey(nameof(Instructor))]
        //int? → Foreign key is optional(NULL allowed).
        public int? instructorId { get; set; }//foreign key of the Instructor (from list)
        public Instructor instructor { get; set; }

        [Required]
        [MaxLength(20)]
        public string courseSemesterOffered { get; set; }//user input
    }
}