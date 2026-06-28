using FlightManagementSystem.Models;
using Microsoft.Win32;

namespace FlightManagementSystem
{
    public class Program
    {
        // Flight Management System Storage
        public static FlightContext context = new FlightContext
        {
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>(),
            Aircrafts = new List<Aircraft>(),
            Flights = new List<Flight>(),
            Bookings = new List<Booking>()
        };
        // Available airports
        public static List<string> airports = new List<string>
        {
            "Muscat",
            "Dubai",
            "Doha",
            "Riyadh"
        };
        // Available times
        public static List<string> departureTimes = new List<string>
         {
          "08:00 AM",
          "12:00 PM",
          "06:00 PM",
          "10:00 PM"
          };
        public static bool IsValidText(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
        // ─────────────────────────────────────────────────────────────────────
        //  01 — Register Passenger
        // ─────────────────────────────────────────────────────────────────────
        public static void RegisterPassenger()
        {
            Console.WriteLine("\n=== Register Passenger ===");
            
            Console.Write("Enter passenger name: ");
            string name = Console.ReadLine().Trim();
            // Validate passenger name
            if (!IsValidText(name) || name.Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger name must contain at least 3 characters");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passenger email: ");
            string email = Console.ReadLine().Trim();

            if (!IsValidText(email)|| !email.Contains("@"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email address");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passenger phone: ");
            string phone = Console.ReadLine().Trim();

            if (!IsValidText(phone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger phone cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passport number: ");
            string passport = Console.ReadLine().Trim();

            if (!IsValidText(passport))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passport number cannot be empty.");
                Console.ResetColor();
                return;
            }
            // Check if passport number already exists
            bool passportExists = context.Passengers.Any(p => p.passportNumber == passport);

            if (passportExists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passport number already exists.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter nationality: ");
            string nationality = Console.ReadLine().Trim();

            if (!IsValidText(nationality))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nationality cannot be empty.");
                Console.ResetColor();
                return;
            }

            int passengerId = context.Passengers.Count + 1;//Generate unique passenger ID
            // Add passenger to system storage
            context.Passengers.Add(new Passenger
            {
                passengerId = passengerId,
                passengerName = name,
                passengerEmail = email,
                passengerPhone = phone,
                passportNumber = passport,
                nationality = nationality
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Passenger registered successfully. Assigned ID: " + passengerId);
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        //  02 — Add Aircraft
        // Add a new aircraft and set it as operational by default
        // ─────────────────────────────────────────────────────────────────────
        public static void AddAircraft()
        {
            Console.WriteLine("\n=== Add Aircraft ===");

            Console.Write("Enter aircraft model: ");
            string model = Console.ReadLine().Trim();

            if (!IsValidText(model))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aircraft model cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter total seats: ");
            if (!int.TryParse(Console.ReadLine(), out int totalSeats))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number.");
                Console.ResetColor();
                return;
            }

            if (totalSeats <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Total seats must be greater than 0.");
                Console.ResetColor();
                return;
            }


            // Generate unique aircraft ID
            int aircraftId = context.Aircrafts.Count + 1;

                // Add aircraft to system storage
                context.Aircrafts.Add(new Aircraft
                {
                    aircraftId = aircraftId,
                    model = model,
                    totalSeats = totalSeats,
                    isOperational = true
                });
            
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aircraft added successfully. Assigned ID: " + aircraftId);
                Console.ResetColor();
            }
        // ─────────────────────────────────────────────────────────────────────
        //  03 — Register Pilot
        // Register a new pilot and set availability to true by default
        // ─────────────────────────────────────────────────────────────────────
        public static void RegisterPilot()
        {
           

                Console.WriteLine("\n=== Register Pilot ===");

                Console.Write("Enter pilot name: ");
                string name = Console.ReadLine().Trim();

                if (!IsValidText(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pilot name cannot be empty.");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Enter pilot phone: ");
                string phone = Console.ReadLine().Trim();

                if (!IsValidText(phone))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pilot phone cannot be empty.");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Enter license number: ");
                string license = Console.ReadLine().Trim();

                if (!IsValidText(license))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("License number cannot be empty.");
                    Console.ResetColor();
                    return;
                }

                // Check if license number already exists
                bool licenseExists = context.Pilots.Any(p => p.licenseNumber == license);

                if (licenseExists)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("License number already exists.");
                    Console.ResetColor();
                    return;
                }

                // Generate unique pilot ID
                int pilotId = context.Pilots.Count + 1;

                // Add pilot to system storage
                context.Pilots.Add(new Pilot
                {
                    pilotId = pilotId,
                    pilotName = name,
                    pilotPhone = phone,
                    licenseNumber = license,
                    flightHours = 0,
                    isAvailable = true
                });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pilot registered successfully. Assigned ID: " + pilotId);
            
            }
        // ─────────────────────────────────────────────────────────────────────
        // 04 — View All Flights
        // Display all scheduled flights in the system
        // ─────────────────────────────────────────────────────────────────────
        public static void ViewAllFlights()
        {
            Console.WriteLine("\n=== View All Flights ===");

            // Check if there are flights in the system
            if (context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found.");
                Console.ResetColor();
                return;
            }

            foreach (Flight flight in context.Flights)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Flight Code: " + flight.flightCode);
                Console.WriteLine("Origin: " + flight.origin);
                Console.WriteLine("Destination: " + flight.destination);
                Console.WriteLine("Departure Date: " + flight.departureDate);
                Console.WriteLine("Departure Time: " + flight.departureTime);
                Console.WriteLine("Available Seats: " + flight.availableSeats);
                Console.WriteLine("Ticket Price: " + flight.ticketPrice);
                Console.WriteLine("Status: " + flight.status);
            }
        }
        // ─────────────────────────────────────────────────────────────────────
        // 05 — Schedule Flight
        // Create a new flight using an operational aircraft and available pilot
        // ─────────────────────────────────────────────────────────────────────
        public static void ScheduleFlight()
        {
            Console.WriteLine("\n=== Schedule Flight ===");

            // Check if aircrafts exist before scheduling a flight
            if (context.Aircrafts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No aircrafts found.\n Please add aircraft first.");
                Console.ResetColor();
                return;
            }

            // Check if pilots exist before scheduling a flight
            if (context.Pilots.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No pilots found. \nPlease register pilot first.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nAvailable Operational Aircrafts:");

            // Display operational aircrafts available for assignment
            foreach (Aircraft aircraft in context.Aircrafts.Where(a => a.isOperational == true))
            {
                Console.WriteLine("ID: " + aircraft.aircraftId +
                                  " | Model: " + aircraft.model +
                                  " | Seats: " + aircraft.totalSeats);
            }

            Console.Write("Enter aircraft ID: ");
            if(!int.TryParse(Console.ReadLine(),out int aircraftId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid aircraft ID.");
                Console.ResetColor();
                return;
            }

            // Select aircraft by ID
            Aircraft selectedAircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == aircraftId && a.isOperational == true);

            // Validate selected aircraft
            if (selectedAircraft == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aircraft not found or not operational.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nAvailable Pilots:");

            // Display available pilots
            foreach (Pilot pilot in context.Pilots.Where(p => p.isAvailable == true))
            {
                Console.WriteLine("ID: " + pilot.pilotId +
                                  " | Name: " + pilot.pilotName +
                                  " | Hours: " + pilot.flightHours);
            }

            Console.Write("Enter pilot ID: ");
            if (!int.TryParse(Console.ReadLine(), out int pilotId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid pilot ID.");
                Console.ResetColor();
                return;
            }
            // Select pilot by ID
            Pilot selectedPilot = context.Pilots.FirstOrDefault(p => p.pilotId == pilotId && p.isAvailable == true);

            // Validate selected pilot
            if (selectedPilot == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pilot not found or not available.");
                Console.ResetColor();
                return;
            }

            // Display airport list for origin
            Console.WriteLine("\nAvailable Airports:");
            for (int i = 0; i < airports.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + airports[i]);
            }

            Console.Write("Select origin: ");
            if (!int.TryParse(Console.ReadLine(), out int originChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid origin choice.");
                Console.ResetColor();
                return;
            }
            if (originChoice < 1 || originChoice > airports.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid origin choice.");
                Console.ResetColor();
                return;
            }

            string origin = airports[originChoice - 1];

            // Display airport list for destination
            Console.WriteLine("\nAvailable Airports:");
            for (int i = 0; i < airports.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + airports[i]);
            }

            Console.Write("Select destination: ");
            if (!int.TryParse(Console.ReadLine(), out int destinationChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid destination choice.");
                Console.ResetColor();
                return;
            }
            if (destinationChoice < 1 || destinationChoice > airports.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid destination choice.");
                Console.ResetColor();
                return;
            }

            string destination = airports[destinationChoice - 1];

            // Origin and destination cannot be the same
            if (origin == destination)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Origin and destination cannot be the same.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter departure date (dd/MM/yyyy): ");
            string departureDate = Console.ReadLine().Trim();
            if (!DateTime.TryParse(departureDate, out DateTime departureDateTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid departure date.");
                Console.ResetColor();
                return;
            }

            if (departureDateTime.Date < DateTime.Today)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Departure date cannot be in the past.");
                Console.ResetColor();
                return;
            }

            // Display departure time list
            Console.WriteLine("\nAvailable Departure Times:");
            for (int i = 0; i < departureTimes.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + departureTimes[i]);
            }

            Console.Write("Select departure time: ");
            if (!int.TryParse(Console.ReadLine(), out int timeChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid departure time choice.");
                Console.ResetColor();
                return;
            }
            if (timeChoice < 1 || timeChoice > departureTimes.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid departure time choice.");
                Console.ResetColor();
                return;
            }

            string departureTime = departureTimes[timeChoice - 1];
            // Enter flight duration in hours
            Console.Write("Enter flight duration (hours): ");
            if (!int.TryParse(Console.ReadLine(), out int flightDuration))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid flight duration.");
                Console.ResetColor();
                return;
            }
            // Validate flight duration
            if (flightDuration <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight duration must be greater than 0.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter ticket price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal ticketPrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid ticket price.");
                Console.ResetColor();
                return;
            }
            if (ticketPrice <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ticket price must be greater than 0.");
                Console.ResetColor();
                return;
            }

            // Generate unique flight ID and flight code
            int flightId = context.Flights.Count + 1;
            string flightCode = "FL-" + flightId.ToString("000");

            // Create and store new flight record
            context.Flights.Add(new Flight
            {
                flightId = flightId,
                flightCode = flightCode,
                aircraftId = aircraftId,
                pilotId = pilotId,
                origin = origin,
                destination = destination,
                departureDate = departureDate,
                departureTime = departureTime,
                flightDuration=flightDuration,
                ticketPrice = ticketPrice,
                availableSeats = selectedAircraft.totalSeats,
                status = "Scheduled"
            });

            // Mark pilot as unavailable after assigning him to this flight
            selectedPilot.isAvailable = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight scheduled successfully.\n Flight Code: " + flightCode);
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        // 06 — Book Flight
        // Create a booking for a passenger on a scheduled flight
        // ─────────────────────────────────────────────────────────────────────
        public static void BookFlight()
        {
            Console.WriteLine("\n=== Book Flight ===");

            // Check if passengers exist
            if (context.Passengers.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No passengers found. \nPlease register passenger first.");
                Console.ResetColor();
                return;
            }

            // Check if flights exist
            if (context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found .. \nPlease schedule a flight first.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter passenger ID: ");
            bool result = int.TryParse(Console.ReadLine(), out int passengerId);
            if (!result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid Passenger ID ..");
                Console.ResetColor();
                return;
            }
            // Get passenger object by ID
            Passenger selectedPassenger = context.Passengers.FirstOrDefault(p => p.passengerId == passengerId);

            if (selectedPassenger == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger not found.");
                Console.ResetColor();
                return;
            }

            // Display airport list for destination
            Console.WriteLine("\nAvailable Destinations:");
            for (int i = 0; i < airports.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + airports[i]);
            }

            Console.Write("Select destination: ");
            if (!int.TryParse(Console.ReadLine(), out int destinationChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid destination choice.");
                Console.ResetColor();
                return;
            }

            if (destinationChoice < 1 || destinationChoice > airports.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid destination choice.");
                Console.ResetColor();
                return;
            }

            string destination = airports[destinationChoice - 1];

            // Find scheduled flights to selected destination with available seats
            List<Flight> availableFlights = context.Flights
                .Where(f => f.destination == destination &&
                            f.status == "Scheduled" &&
                            f.availableSeats > 0)
                .ToList();

            if (availableFlights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No scheduled flights available to this destination.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nAvailable Flights:");

            foreach (Flight flight in availableFlights)
            {
                Console.WriteLine("ID: " + flight.flightId +
                                  " | Code: " + flight.flightCode +
                                  " | From: " + flight.origin +
                                  " | To: " + flight.destination +
                                  " | Date: " + flight.departureDate +
                                  " | Time: " + flight.departureTime +
                                  " | Seats: " + flight.availableSeats +
                                  " | Price: " + flight.ticketPrice);
            }

            Console.Write("Enter flight ID to book: ");
            if (!int.TryParse(Console.ReadLine(), out int flightId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid flight ID.");
                Console.ResetColor();
                return;
            }
            // Select flight from the available flights list
            Flight selectedFlight = availableFlights.FirstOrDefault(f => f.flightId == flightId);

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid flight selection.");
                Console.ResetColor();
                return;
            }

            // Generate unique booking ID
            int bookingId = context.Bookings.Count + 1;

            // Generate simple seat number
            string seatNumber = "S" + bookingId.ToString("000");

            // Create booking record
            context.Bookings.Add(new Booking
            {
                bookingId = bookingId,
                passengerId = passengerId,
                flightId = flightId,
                seatNumber = seatNumber,
                bookingDate = DateTime.Now.ToString("dd/MM/yyyy"),
                totalPrice = selectedFlight.ticketPrice,
                status = "Confirmed"
            });

            // Decrease available seats after confirmed booking
            selectedFlight.availableSeats--;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Booking created successfully. Booking ID: " + bookingId +
                              " | Seat: " + seatNumber +
                              " | Total Price: " + selectedFlight.ticketPrice);
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        // 07 — Cancel Booking
        // Cancel a confirmed booking and return the seat to the flight
        // ─────────────────────────────────────────────────────────────────────
        public static void CancelBooking()
        {
            Console.WriteLine("\n=== Cancel Booking ===");

            // Check if bookings exist
            if (context.Bookings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No bookings found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter booking ID to cancel: ");
            if(!int.TryParse(Console.ReadLine(), out int bookingId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid booking ID.");
                Console.ResetColor();
                return;
            }
            // Locate booking by ID
            Booking selectedBooking = context.Bookings.FirstOrDefault(b => b.bookingId == bookingId);

            if (selectedBooking == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Booking not found.");
                Console.ResetColor();
                return;
            }
            // Prevent cancelling an already cancelled booking
            if (selectedBooking.status == "Cancelled")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This booking is already cancelled.");
                Console.ResetColor();
                return;
            }
            // Find the flight linked to this booking
            Flight selectedFlight = context.Flights.FirstOrDefault(f => f.flightId == selectedBooking.flightId);

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Related flight not found.");
                Console.ResetColor();
                return;
            }
            // Update booking status
            selectedBooking.status = "Cancelled";

            // Return seat to the flight
            selectedFlight.availableSeats++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Booking cancelled successfully. Seat returned to flight.");
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        // 08 — Depart Flight
        // Mark a scheduled flight as departed and update pilot flight hours
        // ─────────────────────────────────────────────────────────────────────
        public static void DepartFlight()
        {
            Console.WriteLine("\n=== Depart Flight ===");

            if (context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nScheduled Flights:");
            foreach (Flight flight in context.Flights.Where(f => f.status == "Scheduled"))
            {
                Console.WriteLine("ID: " + flight.flightId +
                                  " | Code: " + flight.flightCode +
                                  " | From: " + flight.origin +
                                  " | To: " + flight.destination +
                                  " | Date: " + flight.departureDate +
                                  " | Time: " + flight.departureTime);
            }

            Console.Write("Enter flight ID to depart: ");
            // Validate flight ID input
            if (!int.TryParse(Console.ReadLine(), out int flightId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid flight ID.");
                Console.ResetColor();
                return;
            }
            // Locate scheduled flight by ID
            Flight selectedFlight = context.Flights.FirstOrDefault(f => f.flightId == flightId && f.status == "Scheduled");

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight not found or not scheduled.");
                Console.ResetColor();
                return;
            }

            // Find the pilot assigned to this flight
            Pilot selectedPilot = context.Pilots.FirstOrDefault(p => p.pilotId == selectedFlight.pilotId);

            if (selectedPilot == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Assigned pilot not found.");
                Console.ResetColor();
                return;
            }

            // Update flight status
            selectedFlight.status = "Departed";

            // Add flight duration to pilot total flight hours
            selectedPilot.flightHours += selectedFlight.flightDuration;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight departed successfully. Pilot hours updated to: "+ selectedPilot.flightHours);
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        // 09 — Cancel Flight
        // Cancel a flight and all related bookings
        // ─────────────────────────────────────────────────────────────────────
        public static void CancelFlight()
        {
            Console.WriteLine("\n=== Cancel Flight ===");
            if (context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter flight ID to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int flightId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid flight ID.");
                Console.ResetColor();
                return;
            }           
            // Find flight by ID

            Flight selectedFlight = context.Flights.FirstOrDefault(f => f.flightId == flightId);

            if (selectedFlight == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight not found.");
                Console.ResetColor();
                return;
            }
            // Mark flight as cancelled
            selectedFlight.status = "Cancelled";
            int affectedBookings = 0;

            // Cancel all confirmed bookings linked to this flight
            // Cancel all confirmed bookings linked to this flight
            foreach (Booking booking in context.Bookings)
            {
                if (booking.flightId == flightId &&
                    booking.status == "Confirmed")
                {
                    booking.status = "Cancelled";
                    affectedBookings++;
                }
            }
            // Find assigned pilot
            Pilot selectedPilot = context.Pilots.FirstOrDefault(p => p.pilotId == selectedFlight.pilotId);

            if (selectedPilot != null)
            {
                // Pilot becomes available again
                selectedPilot.isAvailable = true;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight cancelled successfully.");
            Console.WriteLine("Affected bookings: " + affectedBookings);
            Console.ResetColor();
        }
        // ─────────────────────────────────────────────────────────────────────
        // 10 — Passenger Booking History
        // Display all bookings for one passenger and total confirmed spending
        // ─────────────────────────────────────────────────────────────────────
        public static void PassengerBookingHistory()
        {
            Console.WriteLine("\n=== Passenger Booking History ===");
            Console.Write("Enter Passenger id : ");
            bool result = int.TryParse(Console.ReadLine(), out int passengerId);
            if (!result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid passenger ID.");
                Console.ResetColor();
                return;
            }
            // Find passenger by ID
            Passenger selectedPassenger = context.Passengers.FirstOrDefault(p => p.passengerId == passengerId);
            if (selectedPassenger == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger not found.");
                Console.ResetColor();
                return;
            }
            // Get all bookings for this passenger
            List<Booking> passengerBookings = context.Bookings.Where(b => b.passengerId == passengerId).ToList();
            if (passengerBookings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No bookings found for this passenger.");
                Console.ResetColor();
                return;
            }
            decimal totalSpent = 0;
            foreach (Booking booking in passengerBookings)
            {
                // Find flight related to this booking
                Flight flight = context.Flights.FirstOrDefault(f => f.flightId == booking.flightId);
                if (flight != null)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Flight Code: " + flight.flightCode);
                    Console.WriteLine("Origin: " + flight.origin);
                    Console.WriteLine("Destination: " + flight.destination);
                    Console.WriteLine("Departure Date: " + flight.departureDate);
                    Console.WriteLine("Seat Number: " + booking.seatNumber);
                    Console.WriteLine("Price Paid: " + booking.totalPrice);
                    Console.WriteLine("Booking Status: " + booking.status);

                    // Add only confirmed booking prices to total
                    if (booking.status == "Confirmed")
                    {
                        totalSpent += booking.totalPrice;
                    }
                }
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total amount spent on confirmed bookings: " + totalSpent);
        }
        // ─────────────────────────────────────────────────────────────────────
        // 11 — Flight Revenue & Load Factor Report
        // Display revenue and load factor for all flights
        // ─────────────────────────────────────────────────────────────────────
        public static void FlightRevenueReport()
        {
            Console.WriteLine("\n=== Flight Revenue & Load Factor Report ===");

            if (context.Flights.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found.");
                Console.ResetColor();
                return;
            }
            // Generate flight report with confirmed bookings and total revenue
            var report = context.Flights
                .Select(f => new
                {
                    flight = f,
                    // Count confirmed bookings for this flight
                    confirmedBookings = context.Bookings
                        .Count(b => b.flightId == f.flightId && b.status == "Confirmed"),
                    // Calculate total revenue from confirmed bookings
                    totalRevenue = context.Bookings
                        .Where(b => b.flightId == f.flightId && b.status == "Confirmed")
                        .Sum(b => b.totalPrice)
                })
                // Sort flights by highest revenue first
                .OrderByDescending(x => x.totalRevenue)
                .ToList();
            // Store total revenue from all flights
            decimal grandTotalRevenue = 0;
            // Display report for each flight
            foreach (var item in report)
            {
                Flight flight = item.flight;

                Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.aircraftId == flight.aircraftId);
                // Get total aircraft seats
                int totalSeats = 0;

                if (aircraft != null)
                {
                    totalSeats = aircraft.totalSeats;
                }

                double loadFactor = 0;
                // Calculate flight load factor percentage
                if (totalSeats > 0)
                {
                    loadFactor = (double)item.confirmedBookings / totalSeats * 100;
                }
                // Add flight revenue to overall revenue
                grandTotalRevenue += item.totalRevenue;

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Flight Code: " + flight.flightCode);
                Console.WriteLine("Route: " + flight.origin + " -> " + flight.destination);
                Console.WriteLine("Confirmed Bookings: " + item.confirmedBookings);
                Console.WriteLine("Total Revenue: " + item.totalRevenue);
                Console.WriteLine("Load Factor: " + loadFactor.ToString("0.00") + "%");
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Grand Total Revenue: " + grandTotalRevenue);
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("      Flight Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - Register Passenger");
                Console.WriteLine(" 2  - Add Aircraft");
                Console.WriteLine(" 3  - Register Pilot");
                Console.WriteLine(" 4  - View All Flights");
                Console.WriteLine(" 5  - Schedule Flight");
                Console.WriteLine(" 6  - Book Flight");
                Console.WriteLine(" 7  - Cancel Booking");
                Console.WriteLine(" 8  - Depart Flight");
                Console.WriteLine(" 9  - Cancel Flight");
                Console.WriteLine(" 10 - Passenger Booking History");
                Console.WriteLine(" 11 - Flight Revenue Report");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option.");
                    Console.ResetColor();
                    continue;
                }
                switch (option)
                {
                    case 1: RegisterPassenger(); break;
                    case 2: AddAircraft(); break;
                    case 3: RegisterPilot();break;
                    case 4: ViewAllFlights(); break;
                    case 5: ScheduleFlight(); break;
                    case 6: BookFlight(); break;
                    case 7: CancelBooking(); break;
                    case 8: DepartFlight();    break;
                    case 9: CancelFlight(); break;
                    case 10:PassengerBookingHistory(); break;
                    case 11: FlightRevenueReport(); break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }
                if (exit == false)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }//end of while
            Console.WriteLine("Goodbye!");
        }
    }
}