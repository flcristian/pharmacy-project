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

    // Methods

    public void RunUsersMessage()
    {

    }

    public void RunUsers()
    {

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
}