using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // System Generated
        public int PassengerId { get; set; } // From List
        public int FlightId { get; set; } // From List
        public string SeatNumber { get; set; } // System Generated
        public string BookingDate { get; set; } // System Generated
        public decimal TotalPrice { get; set; } // Calculated
        public string Status { get; set; } // Default Value
    }
}
