using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public bool IsOperational { get; set; }
    }
}
