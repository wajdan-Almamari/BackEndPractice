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
        public Order Order { get; set; } // Navigation Property

        [ForeignKey(nameof(Product))]
        public int productId { get; set; } // Foreign Key
        public Product Product { get; set; } // Navigation Property


        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // User Input
    }
}
