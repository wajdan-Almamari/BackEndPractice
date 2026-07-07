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

        public static void AddProduct()
        {
            Console.WriteLine("\n=== Add New Product ===");

            // Display all categories from database
            List<Category> categories = context.Categories.ToList();

            if (categories.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No categories found. Please add categories first.");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("\nAvailable Categories:");
            foreach (Category category in categories)
            {
                Console.WriteLine("ID: " + category.categoryId +
                                  " | Name: " + category.categoryName);
            }

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid category ID.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int catgoryId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid category ID.");
                Console.ResetColor();
                return;
            }
            Category selectedCategory = categories.FirstOrDefault(c => c.categoryId == categoryId);
            if (selectedCategory == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Category not found.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(productName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product name cannot be empty.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter description: ");
            string description = Console.ReadLine().Trim();

            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price.");
                Console.ResetColor();
                return;
            }
            if (price <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Price must be greater than 0.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter stock quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stockQuantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid stock quantity.");
                Console.ResetColor();
                return;
            }
            if (stockQuantity < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Stock quantity cannot be negative.");
                Console.ResetColor();
                return;
            }
            Console.Write("Enter image URL: ");
            string imageUrl = Console.ReadLine().Trim();

            // Create a new Product object from user inputs
            Product newProduct = new Product
            {
                productName = productName,
                description = description,
                price = price,
                stockQuantity = stockQuantity,
                imageUrl = imageUrl,
                categoryId = selectedCategory.categoryId,
                createdAt = DateTime.Now,
                isAvailable = true
            };

            // Add product to database
            context.Products.Add(newProduct);

            // Save changes to execute INSERT
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product added successfully. Assigned Product ID: " + newProduct.productId);
            Console.ResetColor();
        }

        public static void AddCategory()
        {
            Console.WriteLine("\n=== Add Category ===");

            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Category name cannot be empty.");
                Console.ResetColor();
                return;
            }

            Category newCategory = new Category
            {
                categoryName = categoryName
            };

            context.Categories.Add(newCategory);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category added successfully.");
            Console.ResetColor();
        }
        public static void PlaceOrder()
        {
            Console.WriteLine("\n=== Place an Order ===");

            // Check if users exist
            if (!context.Users.Any())
            {
                Console.WriteLine("No users found. Please register a user first.");
                return;
            }

            // Check if products exist
            if (!context.Products.Any())
            {
                Console.WriteLine("No products found. Please add products first.");
                return;
            }
            Console.WriteLine("\nAvailable Users :");
            foreach (var user in context.Users.ToList())
            {
                Console.WriteLine($"User ID : {user.userId} | Username : {user.username}");
            }
            Console.Write("\nEnter User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.Write("Enter a valid User ID : ");
            }
            var selectedUser = context.Users.FirstOrDefault(u => u.userId == userId);
            if (selectedUser == null)
            {
                Console.WriteLine("User not found ");
                return;
            }
            // Create and save the order first to get orderId
            Order newOrder = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
                totalAmount = 0,
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            bool addMoreProducts = true;
            while (addMoreProducts)
            {
                Console.WriteLine("\nAvailble Products: ");
                foreach (var product in context.Products.ToList())
                {
                    Console.WriteLine(
               $"Product ID: {product.productId} | Name: {product.productName} | Price: {product.price} | Stock: {product.stockQuantity}");
                }
                Console.Write("\nEnter Product ID: ");
                int productId;
                while (!int.TryParse(Console.ReadLine(), out productId))
                {
                    Console.Write("Enter a valid Product ID: ");
                }

                var selectedProduct = context.Products.FirstOrDefault(p => p.productId == productId);

                if (selectedProduct == null)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                if (selectedProduct.stockQuantity <= 0)
                {
                    Console.WriteLine("This product is out of stock.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.Write("Enter a valid quantity: ");
                }

                if (quantity > selectedProduct.stockQuantity)
                {
                    Console.WriteLine("Not enough stock available.");
                    continue;
                }

                // Create OrderItem record
                OrderItem orderItem = new OrderItem
                {
                    orderId = newOrder.orderId,
                    productId = selectedProduct.productId,
                    quantity = quantity,
                    unitPrice = selectedProduct.price
                };

                context.OrderItems.Add(orderItem);

                // Update total amount
                newOrder.totalAmount += selectedProduct.price * quantity;

                // Reduce stock quantity
                selectedProduct.stockQuantity -= quantity;

                Console.WriteLine("Product added to order.");

                Console.Write("\nDo you want to add another product? (y/n): ");
                string answer = Console.ReadLine().ToLower();

                if (answer != "y")
                {
                    addMoreProducts = false;
                }
            }

            context.SaveChanges();

            Console.WriteLine("\nOrder placed successfully!");
            Console.WriteLine($"Order ID: {newOrder.orderId}");
            Console.WriteLine($"Total Amount: {newOrder.totalAmount}");
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n=== E-Commerce System ===");
                Console.WriteLine("1 - Register User");
                Console.WriteLine("2 - Add Category(");
                Console.WriteLine("3 - Add Product");
                Console.WriteLine("4 - Place an Order");
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
                    case 2:
                        AddCategory();
                        break;
                    case 3:
                        AddProduct();
                        break;
                    case 4:
                        PlaceOrder();
                        break;
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
      
    

