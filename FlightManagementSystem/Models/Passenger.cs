using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
    }
}
