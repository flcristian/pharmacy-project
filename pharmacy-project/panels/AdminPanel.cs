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
    private String _path;

    // Constructors

    public AdminPanel(String path, User admin)
    {
        _manufacturerService = new ManufacturerService(path + "manufacturers.txt");
        _medicineService = new MedicineService(path + "medicine.txt");
        _orderService = new OrderService(path + "orders.txt");
        _orderDetailsService = new OrderDetailsService(path + "order_details.txt");
        _userService = new UserService(path + "users.txt");
        _user = admin;
        _path = path;
    }

    // Panel Methods

    private void RunUsersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See customer list");
        Console.WriteLine("2 - See admin list");
        Console.WriteLine("3 - Edit customer");
        Console.WriteLine("4 - Remove customer");
        Console.WriteLine("5 - Block customer");
        Console.WriteLine("6 - Unblock customer");
        Console.WriteLine("7 - Make a customer admin");
        Console.WriteLine("8 - Remove an admin");
        Console.WriteLine("9 - Save user list");
        Console.WriteLine("10 - Clear user list");
    }

    private void RunUsers()
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
                    this.RemoveCustomer();
                    break;
                case "5":
                     this.BlockCustomer();
                    break;
                case "6":
                    this.UnblockCustomer();
                    break;
                case "7":
                    this.MakeCustomerAdmin();
                    break;
                case "8":
                    this.RemoveAdmin();
                    break;
                case "9":
                    this.SaveUserList();
                    break;
                case "10":
                    this.ClearUserList();
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
        Console.WriteLine("6 - Edit your account");
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
                case "6":
                    break;
                default:
                    running = false;
                    break;
            }
        }
    }

    // User Service Methods

    private void SeeCustomerList()
    {
        base.DrawLine();
        _userService.Display();
        base.WaitForKey();
    }

    private void SeeAdminList()
    {
        base.DrawLine();
        _userService.DisplayAdmins();
        base.WaitForKey();
    }

    private void EditCustomer()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to edit:");
        String email = Console.ReadLine();

        User customer = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || _userService.IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been edited."))
            {
                this.EditCustomer();
            }
            return;
        }

        // Choose what to edit
        Console.WriteLine("\nChoose what you want to edit:");
        Console.WriteLine("1 - Edit name of customer");
        Console.WriteLine("2 - Edit email of customer");
        Console.WriteLine("3 - Name and email of customer");
        Console.WriteLine("Anything else to cancel.");
        String choice = Console.ReadLine();

        String editedName = customer.Name, editedEmail = customer.Email;
        switch(choice)
        {
            case "1":
                Console.WriteLine("\nEnter the new name of the customer:");
                editedName = Console.ReadLine();
                break;
            case "2":
                Console.WriteLine("\nEnter the new email of the customer:");
                editedEmail = Console.ReadLine();
                while(_userService.FindByEmail(editedEmail) != null!)
                {
                    if(!YesNoChoice("Email is already used.", "Do you want to try again?", "Customer has not been edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new email of the customer:");
                    editedEmail = Console.ReadLine();
                }
                break;
            case "3":
                Console.WriteLine("\nEnter the new name of the customer:");
                editedName = Console.ReadLine();
                Console.WriteLine("\nEnter the new email of the customer:");
                editedEmail = Console.ReadLine();
                while(_userService.FindByEmail(editedEmail) != null!)
                {
                    if(!YesNoChoice("Email is already used.", "Do you want to try again?", "Customer has not been edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new email of the customer:");
                    editedEmail = Console.ReadLine();
                }
                break;
            default:
                base.DrawLine();
                Console.WriteLine("Customer has not been edited.\n");
                break;
        }

        User editedCustomer = new Customer(customer.Id, editedName, editedEmail, customer.Password);

        // Confirming action
        bool edit = YesNoChoice("\nDetails of the edited customer:\n" + editedCustomer, "Are you sure you want to make these changes?", "Customer has not been edited.");
        if(edit)
        {
            _userService.EditById(editedCustomer, editedCustomer.Id);
            base.DrawLine();
            Console.WriteLine("Customer has been edited.\n");
        }
    }

    private void RemoveCustomer()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to remove:");
        String email = Console.ReadLine();

        User customer = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || _userService.IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been removed."))
            {
                this.RemoveCustomer();
            }
            return;
        }

        // Confirming action
        bool remove = YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this customer?", "Customer was not removed.");
        if(remove)
        {
            _userService.RemoveById(customer.Id);
            base.DrawLine();
            Console.WriteLine("Customer was removed.\n");
        }
    }

    private void BlockCustomer()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to block:");
        String email = Console.ReadLine();

        User customer = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || _userService.IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been blocked."))
            {
                this.BlockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to block ^", "Are you sure you want to block this customer?", "Customer was not blocked");
        if(block)
        {
            _userService.BlockById(customer.Id);
            base.DrawLine();
            Console.WriteLine("Customer has been blocked.\n");
        }
    }

    private void UnblockCustomer()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to unblock:");
        String email = Console.ReadLine();

        User customer = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || _userService.IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been unblocked."))
            {
                this.UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to unblock ^", "Are you sure you want to unblock this customer?", "Customer was not unblocked");
        if(block)
        {
            _userService.UnblockById(customer.Id);
            base.DrawLine();
            Console.WriteLine("Customer has been unblocked.\n");
        }
    }

    private void MakeCustomerAdmin()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the customer you want to make admin:");
        String email = Console.ReadLine();

        User customer = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || _userService.IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer was assigned as admin."))
            {
                this.UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to make admin ^", "Are you sure you want to make this customer admin?", "Customer was not assigned as admin.");
        if(block)
        {
            Admin admin = new Admin(customer.Id, customer.Name, customer.Email, customer.Password);
            _userService.RemoveById(customer.Id);
            _userService.Add(admin);
            base.DrawLine();
            Console.WriteLine("Customer has been assigned as admin.\n");
        }
    }

    private void RemoveAdmin()
    {
        base.DrawLine();
        Console.WriteLine("Enter the email of the admin you want to remove:");
        String email = Console.ReadLine();

        User admin = _userService.FindByEmail(email);

        // Checks if the customer exists.
        if(admin == null! || !_userService.IsAdmin(admin))
        {
            if(YesNoChoice("No admin has been found with that email.", "Do you want to try again?", "No admin was removed."))
            {
                this.UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(admin);
        bool block = YesNoChoice("This is the admin you want to remove ^", "Are you sure you want to remove this admin?", "Admin was not removed.");
        if(block)
        {
            Customer customer = new Customer(admin.Id, admin.Name, admin.Email, admin.Password);
            _userService.RemoveById(admin.Id);
            _userService.Add(customer);
            base.DrawLine();
            Console.WriteLine("Admin was removed.\n");
        }
    }

    private void SaveUserList()
    {
        // Confirms action
        _userService.Display();
        bool save = YesNoChoice("New user list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "User list was not saved.");
        if(save)
        {
            _userService.SaveList(_path + "users.txt");
            base.DrawLine();
            Console.WriteLine("User list has been saved!\n");
        }
    }

    private void ClearUserList()
    {
        // Confirms action
        bool clear = YesNoChoice("THIS WILL DELETE ALL USERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "User list was not cleared");
        if(clear)
        {
            _userService.ClearList();
            _userService.Add(_user);
            base.DrawLine();
            Console.WriteLine("User list has been cleared!\n");
        }
    }
}