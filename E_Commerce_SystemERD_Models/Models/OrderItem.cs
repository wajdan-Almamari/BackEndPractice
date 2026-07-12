using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce_SystemERD_Models.Models
{
    [PrimaryKey(nameof(orderId), nameof(productId))]
    public class OrderItem
    {
        [ForeignKey(nameof(Order))]
        public int orderId { get; set; } // Foreign Key
        public virtual Order Order { get; set; } // Navigation Property

        [ForeignKey(nameof(Product))]
        public int productId { get; set; } // Foreign Key
        public virtual Product Product { get; set; } // Navigation Property


        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // User Input

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal unitPrice { get; set; }
    }
}
