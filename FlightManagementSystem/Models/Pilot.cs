using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Pilot
    {
        public int PilotId { get; set; }
        public string PilotName { get; set; }
        public string PilotPhone { get; set; }
        public string LicenseNumber { get; set; }
        public int FlightHours { get; set; }
        public bool IsAvailable { get; set; }
    }
}
