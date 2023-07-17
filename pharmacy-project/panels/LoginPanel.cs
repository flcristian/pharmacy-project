using pharmacy_project.user.model;
using pharmacy_project.bases.panel_base;

namespace pharmacy_project.panels
{
    public class LoginPanel : Panel, IPanel
    {
        // Constructors

        public LoginPanel(string path) : base(path) { }

        // Panel Methods

        protected override void RunMessage()
        {
            Console.WriteLine("Choose what you want to do:");
            Console.WriteLine("1 - Log into your account");
            Console.WriteLine("2 - Register a new account");
        }

        public override void Run()
        {
            bool running = true;
            while (running)
            {
                RunMessage();
                string choice = Console.ReadLine();

                DrawLine();
                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    default:
                        running = false;
                        break;
                }
            }
        }

        // Methods

        private string ObtainName()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            return name;
        }

        private string ObtainEmail()
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            return email;
        }

        private string ObtainPassword()
        {
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            return password;
        }

        private void AdminChoice(User user)
        {
            Console.WriteLine("Seems like this is an admin account, how do you want to proceed?:");
            Console.WriteLine("1 - Connect as admin");
            Console.WriteLine("2 - Connect as customer");

            string choice = Console.ReadLine();
            DrawLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Logged in as admin.\nWelcome {user.Name}!\n");
                    AdminPanel adminPanel = new AdminPanel(GetPath(), user);
                    adminPanel.Run();
                    return;
                case "2":
                    Console.WriteLine($"Logged in as customer.\nWelcome {user.Name}!\n");
                    return;
                default:
                    return;
            }
        }

        private void Login()
        {
            // Obtaining credentials
            string email = ObtainEmail();
            string password = ObtainPassword();
            DrawLine();

            // Checking if user exists
            User user = GetUserService().FindByEmailAndPassword(email, password);
            if (user == null!)
            {
                Console.WriteLine("Wrong email or password.\n");
                return;
            }

            // Checking if user is admin
            if (GetUserService().IsAdmin(user))
            {
                AdminChoice(user);
                return;
            }

            // Log in user as customer
            Console.WriteLine($"Welcome {user.Name}!\n");
        }

        private void Register()
        {
            // Obtaining credentials
            string name = ObtainName();
            string email = ObtainEmail();
            string password = ObtainPassword();

            // Creating customer account
            Customer customer = new Customer(GetUserService().NewId(), name, email, password);

            // Adding account to _service
            int add = GetUserService().Add(customer);

            // Checks if user was added or returns errors
            DrawLine();
            if (add == -1)
            {
                Console.WriteLine("Id has already been used! Please try again or contact administrators.\n");
                return;
            }
            if (add == 0)
            {
                Console.WriteLine("Email has already been used.\n");
                return;
            }

            // User has been added, saving list
            GetUserService().SaveList(GetPath());
            Console.WriteLine("Account has been created!\n");
            return;
        }
    }
}

