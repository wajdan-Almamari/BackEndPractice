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
            string name = Console.ReadLine();
            // Validate passenger name
            if (!IsValidText(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger name cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passenger email: ");
            string email = Console.ReadLine();

            if (!IsValidText(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger email cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passenger phone: ");
            string phone = Console.ReadLine();

            if (!IsValidText(phone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passenger phone cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter passport number: ");
            string passport = Console.ReadLine();

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
            string nationality = Console.ReadLine();

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
            string model = Console.ReadLine();

            if (!IsValidText(model))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aircraft model cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter total seats: ");
            int totalSeats = int.Parse(Console.ReadLine());

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
            string name = Console.ReadLine();

            if (!IsValidText(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pilot name cannot be empty.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter pilot phone: ");
            string phone = Console.ReadLine();

            if (!IsValidText(phone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pilot phone cannot be empty.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter license number: ");
            string license = Console.ReadLine();

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
            Console.ResetColor();
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

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: RegisterPassenger(); break;
                    case 2: AddAircraft(); break;
                    case 3:  RegisterPilot();break;
                    case 4: Console.WriteLine("View All Flights"); break;
                    case 5: Console.WriteLine("Schedule Flight"); break;
                    case 6: Console.WriteLine("Book Flight"); break;
                    case 7: Console.WriteLine("Cancel Booking"); break;
                    case 8: Console.WriteLine("Depart Flight"); break;
                    case 9: Console.WriteLine("Cancel Flight"); break;
                    case 10: Console.WriteLine("Passenger Booking History"); break;
                    case 11: Console.WriteLine("Flight Revenue Report"); break;
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