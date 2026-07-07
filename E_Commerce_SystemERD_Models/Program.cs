using E_Commerce_SystemERD_Models.Models;

namespace E_Commerce_SystemERD_Models
{
    public class Program
    {
        public static ECommerceContext context = new ECommerceContext();

        public static void RegisterUser()
        {
            Console.WriteLine("\n=== Register User ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine().Trim();
            bool usernameFound = context.Users.Any(u => u.username == username);

            if (usernameFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email address.");
                Console.ResetColor();
                return;
            }
            bool isEmailTaken = context.Users.Any(u => u.email == email);

            if (isEmailTaken)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email already exists.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password cannot be empty.");
                Console.ResetColor();
                return;
            }
                Console.Write("Enter full name: ");
                string fullName = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Full name cannot be empty.");
                    Console.ResetColor();
                    return;
                }


                Console.Write("Enter phone number: ");
                string phoneNumber = Console.ReadLine().Trim();

                Console.Write("Enter address: ");
                string address = Console.ReadLine().Trim();


                // Create a new User object from user inputs

                User newUser = new User
                {
                    username = username,
                    email = email,
                    passwordHash = password,
                    fullName = fullName,
                    phoneNumber = phoneNumber,
                    address = address,
                    registrationDate = DateTime.Now,
                    isActive = true
                };
                // Add user to database
                context.Users.Add(newUser);

                // Save changes to execute INSERT
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User registered successfully. Assigned User ID: " + newUser.userId);
                Console.ResetColor();
            }

        
            static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n=== E-Commerce System ===");
                Console.WriteLine("1 - Register User");
                Console.WriteLine("0 - Exit");
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
                    case 1:
                        RegisterUser();break;
                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                if (exit == false)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");

        }
    }
}
      
    

