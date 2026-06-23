using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; } //System Generated
        public string Model { get; set; } //User Input
        public int TotalSeats { get; set; } //User Input
        public bool IsOperational { get; set; } //Default Value
    }
}
