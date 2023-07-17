using pharmacy_project.medicine.service;
using pharmacy_project.order.model;
using pharmacy_project.order.service;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details.service;
using pharmacy_project.user.model;
using pharmacy_project.bases.panel_base;

namespace pharmacy_project.panels;

public class CustomerPanel : Panel, IPanel
{
    private MedicineService _medicineService;
    private OrderService _orderService;
    private OrderDetailsService _orderDetailsService;
    private Order _cart;
    private OrderDetails _cartDetails;

    // Constructors

    public CustomerPanel(string path, Customer customer) : base(path, customer)
    {
        _medicineService = new MedicineService(path + "medicine.txt");
        _orderService = new OrderService(path + "orders.txt");
        _orderDetailsService = new OrderDetailsService(path + "order_details.txt");

        _cart = new Order(_orderService.NewId(), GetUser().Id, "Cart");
        _cartDetails = new OrderDetails(_orderDetailsService.NewId(), _cart.Id, new List<int>(), new List<int>());
    }

    // Panel Methods

    protected override void RunMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See medicine list");
        Console.WriteLine("2 - See your cart");
        Console.WriteLine("3 - Add medicine to your cart");
        Console.WriteLine("4 - Remove medicine from cart");
        Console.WriteLine("5 - Edit ammount of medicine");
        Console.WriteLine("6 - Clear cart");
        Console.WriteLine("7 - Place order");
        Console.WriteLine("8 - Edit your account details");
    }

    public override void Run()
    {
        while (true)
        {
            RunMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    SeeMedicineList();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    RunAccount();
                    break;
                default:
                    return;
            }
        }
    }

    // Service Methods

    private void SeeMedicineList()
    {
        _medicineService.Display();
        WaitForKey();
    }
}