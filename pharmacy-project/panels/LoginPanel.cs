using pharmacy_project.user.model;
using pharmacy_project.user.service;
using pharmacy_project.abstract_classes;

namespace pharmacy_project.panels
{
    public class LoginPanel : Panel
    {
        private UserService _service;
        private String _path;

        // Constructors

        public LoginPanel(String path)
        {
            _path = path;
            _service = new UserService(path + "users.txt");
        }
        
        // Methods
        
        public String ObtainName()
        {
            Console.WriteLine("Enter your name:");
            String name = Console.ReadLine();
            return name;
        }
        
        public String ObtainEmail()
        {
            Console.WriteLine("Enter your email:");
            String email = Console.ReadLine();
            return email;
        }
        
        public String ObtainPassword()
        {
            Console.WriteLine("Enter your password:");
            String password = Console.ReadLine();
            return password;
        }
        
        public void AdminChoice(User user)
        {
            Console.WriteLine("Seems like this is an admin account, how do you want to proceed?:");
            Console.WriteLine("1 - Connect as admin");
            Console.WriteLine("2 - Connect as customer");
            
            String choice = Console.ReadLine();
            base.DrawLine();
            switch(choice)
            {
                case "1":
                    Console.WriteLine($"Logged in as admin.\nWelcome {user.Name}!\n");
                    AdminPanel adminPanel = new AdminPanel(_path, user);
                    adminPanel.Run();
                    return;
                case "2":
                    Console.WriteLine($"Logged in as customer.\nWelcome {user.Name}!\n");
                    return;
                default:
                    return;
            }
        }
        
        public void Login()
        {
            // Obtaining credentials
            String email = this.ObtainEmail();
            String password = this.ObtainPassword();
            base.DrawLine();
            
            // Checking if user exists
            User user = _service.FindByEmailAndPassword(email, password);
            if(user == null!)
            {
                Console.WriteLine("Wrong email or password.\n");
                return;
            }
            
            // Checking if user is admin
            if(_service.IsAdmin(user))
            {
                this.AdminChoice(user);
                return;
            }
            
            // Log in user as customer
            Console.WriteLine($"Welcome {user.Name}!\n");
        }
        
        public void Register()
        {
            // Obtaining credentials
            String name = this.ObtainName();
            String email = this.ObtainEmail();
            String password = this.ObtainPassword();
            
            // Creating customer account
            Customer customer = new Customer(_service.NewId(), name, email, password);
            
            // Adding account to _service
            int add = _service.Add(customer);
            
            // Checks if user was added or returns errors
            base.DrawLine();
            if(add == -1)
            {    
                Console.WriteLine("Id has already been used! Please try again or contact administrators.\n");
                return;
            }
            if(add == 0)
            {
                Console.WriteLine("Email has already been used.\n");
                return;
            }
            
            // User has been added, saving list
            String path = "D:\\mycode\\csharp\\projects\\pharmacy-project\\pharmacy-project\\resources\\users.txt";
            _service.SaveList(path);
            Console.WriteLine("Account has been created!\n");
            return;
        }
        
        public override void RunMessage()
        {
            Console.WriteLine("Choose what you want to do:");
            Console.WriteLine("1 - Log into your account");
            Console.WriteLine("2 - Register a new account");
        }
        
        public override void Run()
        {
            bool running = true;
            while(running)
            {
                this.RunMessage();
                String choice = Console.ReadLine();
                
                base.DrawLine();
                switch(choice)
                {
                    case "1":
                        this.Login();
                        break;
                    case "2":
                        this.Register();
                        break;
                    default:
                        running = false;
                        break;
                }
            }
        }
    }
}

