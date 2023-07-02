using pharmacy_project.abstract_classes;
using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.service;
using pharmacy_project.order_details.service;
using pharmacy_project.order.model;
using pharmacy_project.order.service;
using pharmacy_project.user.model;
using pharmacy_project.user.service;

namespace pharmacy_project.panels;

public class AdminPanel : Panel
{
    private ManufacturerService _manufacturerService;
    private MedicineService _medicineService;
    private OrderService _orderService;
    private OrderDetailsService _orderDetailsService;
    private UserService _userService;
    private User _user;

    // Constructors

    public AdminPanel(String path, User admin)
    {
        _manufacturerService = new ManufacturerService(path + "manufacturers.txt");
        _medicineService = new MedicineService(path + "medicine.txt");
        _orderService = new OrderService(path + "orders.txt");
        _orderDetailsService = new OrderDetailsService(path + "order_details.txt");
        _userService = new UserService(path + "users.txt");
        _user = admin;
    }

    // Panel Methods

    public void RunUsersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See customer list");
        Console.WriteLine("2 - See admin list");
        Console.WriteLine("3 - Edit customer");
        Console.WriteLine("4 - Remove customer");
        Console.WriteLine("5 - Block customer");
        Console.WriteLine("6 - Unblock customer");
        Console.WriteLine("7 - Add customer as admin");
    }

    public void RunUsers()
    {
        bool running = true;
        while(running)
        {
            this.RunUsersMessage();
            String choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    this.SeeCustomerList();
                    break;
                case "2":
                    this.SeeAdminList();
                    break;
                case "3":
                    this.EditCustomer();
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                default:
                    running = false;
                    break;
            }
        }
    }

    public override void RunMessage()
    {
        base.DrawLine();
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - Edit manufacturers");
        Console.WriteLine("2 - Edit medicine");
        Console.WriteLine("3 - Edit orders");
        Console.WriteLine("4 - Edit order details");
        Console.WriteLine("5 - Edit users");
    }

    public override void Run()
    {
        if(!_userService.IsAdmin(_user))
        {
            return;
        }

        bool running = true;
        while(running)
        {
            this.RunMessage();
            String choice = Console.ReadLine();

            base.DrawLine();
            switch (choice)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    this.RunUsers();
                    break;
                default:
                    running = false;
                    break;
            }
        }
    }

    // User Service Methods

    public void SeeCustomerList()
    {
        base.DrawLine();
        _userService.Display();
        base.WaitForKey();
    }

    public void SeeAdminList()
    {
        base.DrawLine();
        _userService.DisplayAdmins();
        base.WaitForKey();
    }

    public void EditCustomer()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to edit:");
        String email = Console.ReadLine();

        User user = _userService.FindByEmail(email);

        // Checks if the user exists.
        if(user == null!)
        {
            Console.WriteLine("No user has been found with that email.");
            Console.WriteLine("Do you want to try again? (Y/N)");
            String wrongEmailChoice = Console.ReadLine().ToLower();
            if(wrongEmailChoice.Equals("y") || wrongEmailChoice.Equals("yes"))
            {
                this.EditCustomer();
                }else
            {
                base.DrawLine();
                Console.WriteLine("No user has been edited.\n");
            }
            return;
        }

        User edited = new Customer(user.Id, user.Name, user.Email, user.Password);

        // Choose what to edit
        Console.WriteLine("\nChoose what you want to edit:");
        Console.WriteLine("1 - Edit name of customer");
        Console.WriteLine("2 - Edit email of customer");
        Console.WriteLine("Anything else to cancel.");
        String choice = Console.ReadLine();

        switch(choice)
        {
            case "1":
                break;
            case "2":
                break;
            default:
                base.DrawLine();
                Console.WriteLine("User has not been edited.\n");
                break;
        }

    }
}