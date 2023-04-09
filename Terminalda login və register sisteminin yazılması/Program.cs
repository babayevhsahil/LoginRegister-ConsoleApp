namespace Terminalda_login_və_register_sisteminin_yazılması
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            User admin = new User("Super", "Admin", "admin@gmail.com", "123321", true);
            users.Add(admin);

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. /register");
                Console.WriteLine("2. /login");
                Console.WriteLine("3. /exit");

                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        Register(users);
                        break;

                    case "2":
                        Login(users);
                        break;

                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void Register(List<User> users)
        {
            Console.WriteLine("Registration");
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter your last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm your password:");
            string confirmPassword = Console.ReadLine();

            if (firstName.Length <= 3 || firstName.Length >= 30)
            {
                Console.WriteLine("Invalid first name! It should be between 3 and 30 characters.");
                return;
            }

            if (lastName.Length <= 5 || lastName.Length >= 20)
            {
                Console.WriteLine("Invalid last name! It should be between 5 and 20 characters.");
                return;
            }

            if (!email.Contains("@") || users.Exists(u => u.Email == email))
            {
                Console.WriteLine("Invalid email! It should be unique and contain '@'.");
                return;
            }

            if (password != confirmPassword)
            {
                Console.WriteLine("Passwords do not match!");
                return;
            }

            User newUser = new User(firstName, lastName, email, password);
            users.Add(newUser);
            Console.WriteLine("You successfully registered, now you can login with your new account!");
        }

        static void Login(List<User> users)
        {
            Console.WriteLine("Login");
            Console.WriteLine("Enter your email:");
            string loginEmail = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string loginPassword = Console.ReadLine();

            User user = users.Find(u => u.Email == loginEmail && u.Password == loginPassword);

            if (user == null)
            {
                Console.WriteLine("Invalid email or password!");
                return;
            }

            if (user.IsAdmin)
            {
                Console.WriteLine($"Welcome to your account, our dear admin {user.FirstName} {user.LastName}!");
            }
            else
            {
                Console.WriteLine($"Welcome to your account {user.FirstName} {user.LastName}!");
            }
        }
    }

   public class User
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public bool IsAdmin;

        public User(string firstName, string lastName, string email, string password, bool isAdmin = false)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
