using E_Commerce_SystemERD_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_SystemERD_Models
{
    public class Program
    {
        public static ECommerceContext context = new ECommerceContext();
        // ─────────────────────────────────────────────────────────────────────
        // 01 — Register User [ADD]
        // Register a new user and save user information.
        // ─────────────────────────────────────────────────────────────────────
        public static void RegisterUser()
        {
            // Get username from user
            Console.WriteLine("\n=== Register a New User ===");

            Console.Write("Enter username: ");
            string username = Console.ReadLine().Trim();

            // Check if username already exists
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

            Console.Write("Enter phone number:(optional — press Enter to skip):");
            string phoneNumber = Console.ReadLine().Trim();

            Console.Write("Enter address: (optional — press Enter to skip): ");
            string address = Console.ReadLine().Trim();


            // Create a new User object from user inputs

            User newUser = new User
            {
                username = username,
                email = email,
                passwordHash = password,
                fullName = fullName,
                phoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber,//validation tenery operator
                address = string.IsNullOrWhiteSpace(address) ? null : address,
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
        // ─────────────────────────────────────────────────────────────────────
        // 02 — Add Product to Category [ADD]
        // Create a new product and assign it to a selected category.
        // ─────────────────────────────────────────────────────────────────────
        public static void AddProduct()
        {
            Console.WriteLine("\n=== Add a New Product to a Category ===");

            // Display all categories from database
            ////tolist because it is dbset
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
            // Validate selected category
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
        //public static void AddCategory()
        //{
        //    Console.WriteLine("\n=== Add Category ===");

        //    Console.Write("Enter category name: ");
        //    string categoryName = Console.ReadLine().Trim();

        //    if (string.IsNullOrWhiteSpace(categoryName))
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Category name cannot be empty.");
        //        Console.ResetColor();
        //        return;
        //    }

        //    Category newCategory = new Category
        //    {
        //        categoryName = categoryName
        //    };

        //    context.Categories.Add(newCategory);
        //    context.SaveChanges();

        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("Category added successfully.");
        //    Console.ResetColor();
        //}
        // ─────────────────────────────────────────────────────────────────────
        // 03 — Place an Order [ADD]
        // Create an order, add products, calculate total amount,
        // and update product stock.
        // ─────────────────────────────────────────────────────────────────────
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

            // Display available users
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
            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();

            Console.WriteLine("\nPayment Methods:");
            Console.WriteLine("1 - Cash");
            Console.WriteLine("2 - Card");

            Console.Write("Choose Payment Method: ");
            string choice = Console.ReadLine();

            string paymentMethod = "";

            if (choice == "1")
            {
                paymentMethod = "Cash";
            }
            else if (choice == "2")
            {
                paymentMethod = "Card";
            }
            else
            {
                Console.WriteLine("Invalid payment method.");
                return;
            }
            // Create and save the order first to get orderId
            Order newOrder = new Order
            {
                userId = userId,
                orderDate = DateTime.Now,
                totalAmount = 0,
                shippingAddress = shippingAddress,
                paymentMethod = paymentMethod
            };

            context.Orders.Add(newOrder);
            context.SaveChanges();

            bool addMoreProducts = true;
            while (addMoreProducts)
            {
                // Display available products
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
                // Check if product exists
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
                string answer = Console.ReadLine().Trim().ToLower();

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
        // ─────────────────────────────────────────────────────────────────────
        // 04 — Write a Product Review [ADD]
        // Allow a user to submit a rating and optional comment for a product,
        // then save the review date automatically.
        // ─────────────────────────────────────────────────────────────────────
        public static void WriteProductReview()
        {
            Console.WriteLine("\n=== Write a Product Review ===");

            if (!context.Users.Any())
            {
                Console.WriteLine("No users found.");
                return;
            }

            if (!context.Products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }
            // Display available users
            Console.WriteLine("\nAvailable Users:");
            foreach (var user in context.Users.ToList())
            {
                Console.WriteLine($"User ID: {user.userId} | Username: {user.username}");
            }

            Console.Write("\nEnter User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.Write("Enter a valid User ID: ");
            }

            var selectedUser = context.Users.FirstOrDefault(u => u.userId == userId);

            if (selectedUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("\nAvailable Products:");
            foreach (var product in context.Products.ToList())
            {
                Console.WriteLine($"Product ID: {product.productId} | Name: {product.productName}");
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
                return;
            }
            // Validate rating between 1 and 5
            Console.Write("Enter Rating (1-5): ");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.Write("Enter a valid rating from 1 to 5: ");
            }

            Console.Write("Enter Comment (optional): ");
            string comment = Console.ReadLine();

            // Create review object
            Review review = new Review
            {
                userId = userId,
                productId = productId,
                rating = rating,
                comment = comment,
                reviewDate = DateTime.Now
            };
            // Save review to database
            context.Reviews.Add(review);
            context.SaveChanges();

            Console.WriteLine("Review added successfully!");
        }
        // ─────────────────────────────────────────────────────────────────────
        // 05 — Update Product Price and Availability [UPDATE]
        // Update product price and availability status.
        // ─────────────────────────────────────────────────────────────────────
        public static void UpdateProduct()
        {
            Console.WriteLine("\n=== Update Product Price and Availability ===");

            if (!context.Products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            // Display available products
            foreach (var product in context.Products.ToList())
            {
                Console.WriteLine(
                    $"ID: {product.productId} | Name: {product.productName} | Price: {product.price} | Available: {product.isAvailable}");
            }

            Console.Write("\nEnter Product ID: ");
            int productId;

            while (!int.TryParse(Console.ReadLine(), out productId))
            {
                Console.Write("Enter a valid Product ID: ");
            }

            // Find product
            var selectedProduct = context.Products.FirstOrDefault(p => p.productId == productId);

            if (selectedProduct == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter New Price: ");
            decimal newPrice;

            while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
            {
                Console.Write("Enter a valid price: ");
            }

            Console.Write("Is Product Available? (y/n): ");
            string answer = Console.ReadLine().Trim().ToLower();

            // Update product price and availability
            selectedProduct.price = newPrice;
            selectedProduct.isAvailable = answer == "y";

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Product updated successfully.");
        }
        // ─────────────────────────────────────────────────────────────────────
        // 07 — Delete a Review [DELETE]
        // Delete a review by its ID and remove it from the database.
        // ─────────────────────────────────────────────────────────────────────
        public static void DeleteReview()
        {
            Console.WriteLine("\n=== Delete a Review ===");
            if (!context.Reviews.Any())
            {
                Console.WriteLine("No reviews found.");
                return;
            }
            // Display available reviews
            foreach (var review in context.Reviews.ToList())
            {
                Console.WriteLine(
            $"Review ID: {review.reviewId} | Rating: {review.rating} | Comment: {review.comment}");
            }
            Console.Write("\nEnter Review ID: ");
            int reviewId;
            while (!int.TryParse(Console.ReadLine(), out reviewId))
            {
                Console.Write("Enter a valid Review ID: ");
            }
            // Find review by ID
            var reviewToDelete = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId);
            if (reviewToDelete == null)
            {
                Console.WriteLine("Review not found.");
                return;
            }
            // Remove review from database
            context.Reviews.Remove(reviewToDelete);
            // Save changes
            context.SaveChanges();
            Console.WriteLine($"Review {reviewId} deleted successfully." );
        }
        // ─────────────────────────────────────────────────────────────────────
        // 08 — View All Products [GET-ALL]
        // Display all products with their name, price, stock quantity,
        // and availability status.
        // ─────────────────────────────────────────────────────────────────────
        public static void ViewAllProducts()
        {
            Console.WriteLine("\n=== View All Products ===");

            // Retrieve all products
            List<Product> products = context.Products.ToList();
            if (!products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            Console.WriteLine("\nProducts List:");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.productId} | " +
                    $"Name: {product.productName} | " +
                    $"Price: {product.price} OMR | " +
                    $"Stock: {product.stockQuantity} | " +
                    $"Available: {product.isAvailable}");
            }
        }
        // ─────────────────────────────────────────────────────────────────────
        // 09 — Filter Products by Category and Price Range [FILTER]
        // Display products from a selected category within a specified
        // price range and sort them by price ascending.
        // ─────────────────────────────────────────────────────────────────────
        public static void FilterProducts()
        {
            Console.WriteLine("\n=== Filter Products by Category and Price Range ===");

            // Display available categories
            Console.WriteLine("\nAvailable Categories:");
            foreach (var categroy in context.Categories.ToList())
            {
                Console.WriteLine($"{categroy.categoryId} - {categroy.categoryName}");
            }
            Console.Write("Enter Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            Console.Write("Enter Minimum Price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Maximum Price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            // Filter and sort products
            List<Product> products = context.Products
                .Where(p =>
                           p.categoryId == categoryId &&
                           p.price >= minPrice &&
                           p.price <= maxPrice)
                .OrderBy(p => p.price)
                .ToList();

            if (!products.Any())
            {
                Console.WriteLine("No matching products found.");
                return;
            }
            Console.WriteLine("\nFiltered Products:");

            foreach (Product product in products)
            {
                Console.WriteLine(
                    $"ID: {product.productId} | " +
                    $"Name: {product.productName} | " +
                    $"Price: {product.price} OMR | " +
                    $"Stock: {product.stockQuantity}");
            }
        }
        // ─────────────────────────────────────────────────────────────────────
        // 06 — Cancel an Order [UPDATE]
        // Cancel a pending order and restore stock quantity for all products
        // included in that order.
        // ─────────────────────────────────────────────────────────────────────
        public static void CancelOrder()
        {
            Console.WriteLine("\n=== Cancel an Order ===");

            Console.Write("Enter Order ID: ");
            int orderId;
            while (!int.TryParse(Console.ReadLine(), out orderId)|| orderId <= 0)
            {
                Console.WriteLine("Enter a valid order Ide : ");
            }
            // Find order by ID
            var order = context.Orders.FirstOrDefault(r=>r.orderId == orderId);
            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }
            if(order.status != "Pending")
            {
                Console.WriteLine("Only pending orders can be cancelled.");
                return;
            }
            // Load all order items for this order
            var orderItems = context.OrderItems
                .Where(o=> o.orderId == orderId)
                .ToList();
            // Restore stock quantity for each product in the order
            foreach (var item in orderItems)
            {
                var product = context.Products.FirstOrDefault(p => p.productId == item.productId); 
                if (product != null)
                {
                    product.stockQuantity += item.quantity;
                }
            }
            // Update order status
            order.status = "Cancelled";
            context.SaveChanges();
            Console.WriteLine("Order cancelled successfully and stock restored.");
        }
        // ─────────────────────────────────────────────────────────────────────
        // 10 — Get Category with All Its Products [INCLUDE]
        // Display a category and all products that belong to it using
        // eager loading with Include().
        // ─────────────────────────────────────────────────────────────────────
        public static void GetCategoryWithProducts()
        {
            Console.WriteLine("\n=== Get Category with All Its Products ===");
            Console.Write("Enter Category ID: ");
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId) || categoryId <= 0)
            {
                Console.Write("Enter a valid Category ID: ");
            }
            // Get category and its products in a single query
            //loading all needed data
            Category category = context.Categories
                              .Include(c => c.Products)
                       //     .ThenInclude(p=> p.Reviews)
                       //     .ThenInclude(r=>r.User)
                       //     .ThenInclude(o=>o.Orders)
                              .FirstOrDefault(c => c.categoryId == categoryId);
            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }
            // Display category details
            Console.WriteLine($"\nCategory Name: {category.categoryName}");
            Console.WriteLine($"Description: {category.description}");
            Console.WriteLine($"\nProducts: {category.Products.Count}");
            if (!category.Products.Any())
            {
                Console.WriteLine($"No products{categoryId} found in this category.");
                return;
            }
            // Display products
            Console.WriteLine("\nProducts:");
            foreach(var product in category.Products)
            {
            Console.WriteLine(
               $"ID: {product.productId} | " +
               $"Name: {product.productName} | " +
               $"Price: {product.price} OMR | " +
               $"Stock: {product.stockQuantity}");
            }
        }
        // ─────────────────────────────────────────────────────────────────────
        // 11 — View Order History with Full Details [INCLUDE]
        // Display a user's orders with order items and product details
        // using Include and ThenInclude.
        // ─────────────────────────────────────────────────────────────────────
        public static void ViewOrderHistory()
        {
            Console.WriteLine("\n=== View Order History with Full Details ===");
            Console.Write("Enter User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId) || userId <= 0)
            {
                Console.Write("Enter a valid User ID: ");
            }

            // Get user with orders, order items, and products in a single chained query
            User user = context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(u => u.userId == userId);
            // Check if user exists
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            // Check if user has any orders
            if (!user.Orders.Any())
            {
                Console.WriteLine("No orders found for this user.");
                return;
            }
            // Display user order history
            Console.WriteLine($"\nOrder History for: {user.username}");
            foreach (Order order in user.Orders)
            {
                // Display order details
                Console.WriteLine($"\nOrder ID: {order.orderId}");
                Console.WriteLine($"Date: {order.orderDate}");
                Console.WriteLine($"Status: {order.status}");
                Console.WriteLine($"Total: {order.totalAmount} OMR");

                // Display order items
                Console.WriteLine("Items:");

                foreach (OrderItem item in order.OrderItems)
                {
                    Console.WriteLine(
                        $"- Product: {item.Product.productName} | " +
                        $"Unit Price: {item.unitPrice} OMR | " +
                        $"Quantity: {item.quantity}");
                }

            }
        }
        // ─────────────────────────────────────────────────────────────────────
        // 12 — Product Summary Report [PROJECT] [LAZY]
        // Generate a product summary report using projection, then demonstrate
        // lazy loading by accessing a navigation property without Include.
        // ─────────────────────────────────────────────────────────────────────
        public static void ProductSummaryReport()
        {
            Console.WriteLine("\n=== Product Summary Report ===");
            // Project product summary into an anonymous object
            //Part A: Projection query
            var report = context.Products
                .Select(p => new
                {
                    ProductName = p.productName,
                    CategoryName = p.Category.categoryName,
                    ReviewCount = p.Reviews.Count(),
                    // If there are no reviews
                    // set average rating to 0 to avoid Average() error
                    AvgRating = p.Reviews.Count() == 0 ? 0.0 : p.Reviews.Average(r => (double)r.rating),
                    Stock = p.stockQuantity
                }).ToList();
            foreach (var item in report)
            {
                Console.WriteLine(
                    $"Product: {item.ProductName} | " +
                    $"Category: {item.CategoryName} | " +
                    $"Reviews: {item.ReviewCount} | " +
                    $"Average Rating: {item.AvgRating} | " +
                    $"Stock: {item.Stock}");
            }
            // Part B: Lazy Loading demo
            var product = context.Products.FirstOrDefault();
            if (product == null)
            {
                Console.WriteLine("No products found.");
                return;
            }
            Console.WriteLine($"\nLazy Loading Demo Product: {product.productName}");
            // Second query fires here when Reviews is accessed
            var reviews = product.Reviews.ToList();
            Console.WriteLine($"Review Count: {reviews.Count}");

        }

        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("\n=== E-Commerce System ===");
                Console.WriteLine("1 - Register User");
                //Console.WriteLine("2 - Add Category ");
                Console.WriteLine("2 - Add a New Product to a Category");
                Console.WriteLine("3 - Place an Order");
                Console.WriteLine("4 - Write a Product Review");
                Console.WriteLine("5 - Update Product Price and Availability");
                Console.WriteLine("6 - Cancel an Order");
                Console.WriteLine("7 - Delete a Review");
                Console.WriteLine("8 - View All Products ");
                Console.WriteLine("9 - Filter Products by Category and Price Range ");
                Console.WriteLine("10- Get Category with All Its Products");
                Console.WriteLine("11- View Order History with Full Details");
                Console.WriteLine("12- Product Summary Report ");
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
                    case 1: RegisterUser();break;
                    //case 2: AddCategory();break;
                    case 2: AddProduct();break;
                    case 3: PlaceOrder(); break;
                    case 4: WriteProductReview(); break;
                    case 5: UpdateProduct(); break;
                    case 6: CancelOrder(); break;
                    case 7: DeleteReview(); break;
                    case 8: ViewAllProducts(); break;
                    case 9: FilterProducts(); break;
                    case 10: GetCategoryWithProducts(); break;
                    case 11: ViewOrderHistory(); break;
                    case 12: ProductSummaryReport(); break;
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
      
    

