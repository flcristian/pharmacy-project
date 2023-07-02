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

    // Constructors

    public AdminPanel(String path, User admin) : base(path, admin)
    {
        _manufacturerService = new ManufacturerService(path + "manufacturers.txt");
        _medicineService = new MedicineService(path + "medicine.txt");
        _orderService = new OrderService(path + "orders.txt");
        _orderDetailsService = new OrderDetailsService(path + "order_details.txt");
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
            RunUsersMessage();
            String choice = Console.ReadLine();

            DrawLine();
            switch(choice)
            {
                case "1":
                    SeeCustomerList();
                    break;
                case "2":
                    SeeAdminList();
                    break;
                case "3":
                    EditCustomer();
                    break;
                case "4":
                    RemoveCustomer();
                    break;
                case "5":
                     BlockCustomer();
                    break;
                case "6":
                    UnblockCustomer();
                    break;
                case "7":
                    MakeCustomerAdmin();
                    break;
                case "8":
                    RemoveAdmin();
                    break;
                case "9":
                    SaveUserList();
                    break;
                case "10":
                    ClearUserList();
                    break;
                default:
                    return;
            }
        }
    }

    public override void RunMessage()
    {
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
        // Checks if the user is an admin.
        if(!GetUserService().IsAdmin(GetUser()))
        {
            DrawLine();
            Console.WriteLine("YOU DO NOT HAVE PERMISSION!\n");
            return;
        }

        bool running = true;
        while(running)
        {
            RunMessage();
            String choice = Console.ReadLine();

            DrawLine();
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
                    RunUsers();
                    break;
                case "6":
                    RunAccount();
                    break;
                default:
                    return;
            }
        }
    }

    // User Service Methods

    private void SeeCustomerList()
    {
        GetUserService().Display();
        WaitForKey();
    }

    private void SeeAdminList()
    {
        GetUserService().DisplayAdmins();
        WaitForKey();
    }

    private void EditCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to edit:");
        String email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || GetUserService().IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been edited."))
            {
                EditCustomer();
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

                if(editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("You must imput a name!", "Do you want to try again?", "Account was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the customer:");
                    editedName = Console.ReadLine();
                }
                break;
            case "2":
                Console.WriteLine("\nEnter the new email of the customer:");
                editedEmail = Console.ReadLine();
                while(GetUserService().FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Customer was not edited."))
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
                if(editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("You must imput a name!", "Do you want to try again?", "Account was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the customer:");
                    editedName = Console.ReadLine();
                }

                Console.WriteLine("\nEnter the new email of the customer:");
                editedEmail = Console.ReadLine();
                while(GetUserService().FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
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
                DrawLine();
                Console.WriteLine("Customer has not been edited.\n");
                return;
        }

        User editedCustomer = new Customer(customer.Id, editedName, editedEmail, customer.Password);

        // Confirming action
        bool edit = YesNoChoice("\nDetails of the edited customer:\n" + editedCustomer, "Are you sure you want to make these changes?", "Customer has not been edited.");
        if(edit)
        {
            GetUserService().EditById(editedCustomer, editedCustomer.Id);
            DrawLine();
            Console.WriteLine("Customer has been edited.\n");
        }
    }

    private void RemoveCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to remove:");
        String email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || GetUserService().IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been removed."))
            {
                RemoveCustomer();
            }
            return;
        }

        // Confirming action
        bool remove = YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this customer?", "Customer was not removed.");
        if(remove)
        {
            GetUserService().RemoveById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer was removed.\n");
        }
    }

    private void BlockCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to block:");
        String email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || GetUserService().IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been blocked."))
            {
                BlockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to block ^", "Are you sure you want to block this customer?", "Customer was not blocked");
        if(block)
        {
            GetUserService().BlockById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer has been blocked.\n");
        }
    }

    private void UnblockCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to unblock:");
        String email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || GetUserService().IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been unblocked."))
            {
                UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to unblock ^", "Are you sure you want to unblock this customer?", "Customer was not unblocked");
        if(block)
        {
            GetUserService().UnblockById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer has been unblocked.\n");
        }
    }

    private void MakeCustomerAdmin()
    {
        Console.WriteLine("Enter the email of the customer you want to make admin:");
        String email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(customer == null! || GetUserService().IsAdmin(customer))
        {
            if(YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer was assigned as admin."))
            {
                UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        bool block = YesNoChoice("This is the customer you want to make admin ^", "Are you sure you want to make this customer admin?", "Customer was not assigned as admin.");
        if(block)
        {
            Admin admin = new Admin(customer.Id, customer.Name, customer.Email, customer.Password);
            GetUserService().RemoveById(customer.Id);
            GetUserService().Add(admin);
            DrawLine();
            Console.WriteLine("Customer has been assigned as admin.\n");
        }
    }

    private void RemoveAdmin()
    {
        Console.WriteLine("Enter the email of the admin you want to remove:");
        String email = Console.ReadLine();

        User admin = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if(admin == null! || !GetUserService().IsAdmin(admin))
        {
            if(YesNoChoice("No admin has been found with that email.", "Do you want to try again?", "No admin was removed."))
            {
                UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(admin);
        bool block = YesNoChoice("This is the admin you want to remove ^", "Are you sure you want to remove this admin?", "Admin was not removed.");
        if(block)
        {
            Customer customer = new Customer(admin.Id, admin.Name, admin.Email, admin.Password);
            GetUserService().RemoveById(admin.Id);
            GetUserService().Add(customer);
            DrawLine();
            Console.WriteLine("Admin was removed.\n");
        }
    }

    private void SaveUserList()
    {
        // Confirms action
        GetUserService().Display();
        bool save = YesNoChoice("New user list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "User list was not saved.");
        if(save)
        {
            GetUserService().SaveList(GetPath() + "users.txt");
            DrawLine();
            Console.WriteLine("User list has been saved!\n");
        }
    }

    private void ClearUserList()
    {
        // Confirms action
        bool clear = YesNoChoice("THIS WILL DELETE ALL USERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "User list was not cleared");
        if(clear)
        {
            GetUserService().ClearList();
            GetUserService().Add(GetUser());
            DrawLine();
            Console.WriteLine("User list has been cleared!\n");
        }
    }
}