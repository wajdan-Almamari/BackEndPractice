using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int FlightId { get; set; } // System Generated
        public string FlightCode { get; set; } // System Generated
        public int AircraftId { get; set; } // From List
        public int PilotId { get; set; } // From List
        public string Origin { get; set; } // User Input
        public string Destination { get; set; } // User Input
        public string DepartureDate { get; set; } // User Input
        public string DepartureTime { get; set; } // User Input
        public decimal TicketPrice { get; set; } // User Input
        public int AvailableSeats { get; set; } // Calculated
        public string Status { get; set; } // Default Value
    }
}
