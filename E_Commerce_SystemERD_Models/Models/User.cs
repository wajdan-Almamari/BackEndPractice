using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce_SystemERD_Models.Models
{
   
        [Index(nameof(username), IsUnique = true)]
        [Index(nameof(email), IsUnique = true)]
        public class User
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int userId { get; set; } // system generated

            [Required]
            [MaxLength(50)]
            public string username { get; set; } // user input

            [Required]
            [MaxLength(150)]
            public string email { get; set; } // user input

            [Required]
            [MaxLength(256)]
            public string passwordHash { get; set; } // user input

            [Required]
            [MaxLength(100)]
            public string fullName { get; set; } // user input

            [MaxLength(20)]
            public string? phoneNumber { get; set; } // user input

            [MaxLength(300)]
            public string? address { get; set; } // user input

            [Required]
            public DateTime registrationDate { get; set; } // system generated

            [DefaultValue(true)]
            public bool isActive { get; set; } // default value

        }
    }


