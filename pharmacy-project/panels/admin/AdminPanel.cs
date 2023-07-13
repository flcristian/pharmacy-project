using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
using pharmacy_project.medicine.service;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details.service;
using pharmacy_project.order.model;
using pharmacy_project.order.service;
using pharmacy_project.user.model;
using pharmacy_project.bases.panel_base;

namespace pharmacy_project.panels.admin;

public class AdminPanel : Panel, IAdminPanel
{
    public IManufacturerService _manufacturerService;
    public IMedicineService _medicineService;
    public IOrderService _orderService;
    public IOrderDetailsService _orderDetailsService;

    // Constructors

    public AdminPanel(string path, User admin) : base(path, admin)
    {
        _manufacturerService = new ManufacturerService(path + "manufacturers.txt");
        _medicineService = new MedicineService(path + "medicine.txt");
        _orderService = new OrderService(path + "orders.txt");
        _orderDetailsService = new OrderDetailsService(path + "order_details.txt");
    }

    // Panel Methods

    public void RunManufacturersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See manufacturer list");
        Console.WriteLine("2 - Add manufacturer");
        Console.WriteLine("3 - Edit manufacturer");
        Console.WriteLine("4 - Remove manufacturer");
        Console.WriteLine("5 - Save manufacturer list");
        Console.WriteLine("6 - Clear manufacturer list");
    }

    public void RunManufacturers()
    {
        while (true)
        {
            RunManufacturersMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    SeeManufacturerList();
                    break;
                case "2":
                    AddManufacturer();
                    break;
                case "3":
                    EditManufacturer();
                    break;
                case "4":
                    RemoveManufacturer();
                    break;
                case "5":
                    SaveManufacturerList();
                    break;
                case "6":
                    ClearManufacturerList();
                    break;
                default:
                    return;
            }
        }
    }

    public void RunMedicineMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See medicine list");
        Console.WriteLine("2 - Add medicine");
        Console.WriteLine("3 - Edit medicine");
        Console.WriteLine("4 - Remove medicine");
        Console.WriteLine("5 - Save medicine list");
        Console.WriteLine("6 - Clear medicine list");
    }

    public void RunMedicine()
    {
        while (true)
        {
            RunMedicineMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    SeeMedicineList();
                    break;
                case "2":
                    AddMedicine();
                    break;
                case "3":
                    EditMedicine();
                    break;
                case "4":
                    RemoveMedicine();
                    break;
                case "5":
                    SaveMedicineList();
                    break;
                case "6":
                    ClearMedicineList();
                    break;
                default:
                    return;
            }
        }
    }

    public void RunOrdersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See order list");
        Console.WriteLine("2 - Edit status of order");
        Console.WriteLine("3 - Remove order");
        Console.WriteLine("4 - Save order list");
        Console.WriteLine("5 - Clear order list");
    }

    public void RunOrders()
    {
        while (true)
        {
            RunOrdersMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    SeeOrderList();
                    break;
                case "2":
                    EditStatusOfOrder();
                    break;
                case "3":
                    RemoveOrder();
                    break;
                case "4":
                    SaveOrderList();
                    break;
                case "5":
                    ClearOrderList();
                    break;
                default:
                    return;
            }
        }
    }

    public void RunOrderDetailsMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See order details list");
        Console.WriteLine("2 - Edit order details");
        Console.WriteLine("3 - Save order details list");
    }

    public void RunOrderDetails()
    {
        while (true)
        {
            RunOrderDetailsMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    SeeOrderDetailsList();
                    break;
                case "2":
                    EditOrderDetails();
                    break;
                case "3":
                    SaveOrderDetailsList();
                    break;
                default:
                    return;
            }
        }
    }

    public void RunUsersMessage()
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

    public void RunUsers()
    {
        while (true)
        {
            RunUsersMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
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
        if (!GetUserService().IsAdmin(GetUser()))
        {
            DrawLine();
            Console.WriteLine("YOU DO NOT HAVE PERMISSION!\n");
            return;
        }

        while (true)
        {
            RunMessage();
            string choice = Console.ReadLine();

            DrawLine();
            switch (choice)
            {
                case "1":
                    RunManufacturers();
                    break;
                case "2":
                    RunMedicine();
                    break;
                case "3":
                    RunOrders();
                    break;
                case "4":
                    RunOrderDetails();
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

    // User service methods

    public void SeeCustomerList()
    {
        GetUserService().Display();
        WaitForKey();
    }

    public void SeeAdminList()
    {
        GetUserService().DisplayAdmins();
        WaitForKey();
    }

    public void EditCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to edit:");
        string email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (customer == null! || GetUserService().IsAdmin(customer))
        {
            if (YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been edited."))
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
        string choice = Console.ReadLine();

        string editedName = customer.Name, editedEmail = customer.Email;
        switch (choice)
        {
            case "1":
                Console.WriteLine("\nEnter the new name of the customer:");
                editedName = Console.ReadLine();

                if (editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("You must input a name!", "Do you want to try again?", "Account was not edited."))
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
                while (GetUserService().FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Customer was not edited."))
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
                if (editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("You must input a name!", "Do you want to try again?", "Account was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the customer:");
                    editedName = Console.ReadLine();
                }

                Console.WriteLine("\nEnter the new email of the customer:");
                editedEmail = Console.ReadLine();
                while (GetUserService().FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("Email is already used.", "Do you want to try again?", "Customer has not been edited."))
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
        if (YesNoChoice("\nDetails of the edited customer:\n" + editedCustomer, "Are you sure you want to make these changes?", "Customer has not been edited."))
        {
            GetUserService().EditById(editedCustomer, editedCustomer.Id);
            DrawLine();
            Console.WriteLine("Customer has been edited.\n");
        }
    }

    public void RemoveCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to remove:");
        string email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (customer == null! || GetUserService().IsAdmin(customer))
        {
            if (YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been removed."))
            {
                RemoveCustomer();
            }
            return;
        }

        // Confirming action
        if (YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this customer?", "Customer was not removed."))
        {
            GetUserService().RemoveById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer was removed.\n");
        }
    }

    public void BlockCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to block:");
        string email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (customer == null! || GetUserService().IsAdmin(customer))
        {
            if (YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been blocked."))
            {
                BlockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        if (YesNoChoice("This is the customer you want to block ^", "Are you sure you want to block this customer?", "Customer was not blocked"))
        {
            GetUserService().BlockById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer has been blocked.\n");
        }
    }

    public void UnblockCustomer()
    {
        Console.WriteLine("Enter the email of the customer you want to unblock:");
        string email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (customer == null! || GetUserService().IsAdmin(customer))
        {
            if (YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer has been unblocked."))
            {
                UnblockCustomer();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        if (YesNoChoice("This is the customer you want to unblock ^", "Are you sure you want to unblock this customer?", "Customer was not unblocked"))
        {
            GetUserService().UnblockById(customer.Id);
            DrawLine();
            Console.WriteLine("Customer has been unblocked.\n");
        }
    }

    public void MakeCustomerAdmin()
    {
        Console.WriteLine("Enter the email of the customer you want to make admin:");
        string email = Console.ReadLine();

        User customer = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (customer == null! || GetUserService().IsAdmin(customer))
        {
            if (YesNoChoice("No customer has been found with that email.", "Do you want to try again?", "No customer was assigned as admin."))
            {
                MakeCustomerAdmin();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        if (YesNoChoice("This is the customer you want to make admin ^", "Are you sure you want to make this customer admin?", "Customer was not assigned as admin."))
        {
            Admin admin = new Admin(customer.Id, customer.Name, customer.Email, customer.Password);
            GetUserService().RemoveById(customer.Id);
            GetUserService().Add(admin);
            DrawLine();
            Console.WriteLine("Customer has been assigned as admin.\n");
        }
    }

    public void RemoveAdmin()
    {
        Console.WriteLine("Enter the email of the admin you want to remove:");
        string email = Console.ReadLine();

        User admin = GetUserService().FindByEmail(email);

        // Checks if the customer exists.
        if (admin == null! || !GetUserService().IsAdmin(admin))
        {
            if (YesNoChoice("No admin has been found with that email.", "Do you want to try again?", "No admin was removed."))
            {
                RemoveAdmin();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(admin);
        if (YesNoChoice("This is the admin you want to remove ^", "Are you sure you want to remove this admin?", "Admin was not removed."))
        {
            Customer customer = new Customer(admin.Id, admin.Name, admin.Email, admin.Password);
            GetUserService().RemoveById(admin.Id);
            GetUserService().Add(customer);
            DrawLine();
            Console.WriteLine("Admin was removed.\n");
        }
    }

    public void SaveUserList()
    {
        // Confirms action
        GetUserService().Display();
        if (YesNoChoice("User list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "User list was not saved."))
        {
            GetUserService().SaveList(GetPath() + "users.txt");
            DrawLine();
            Console.WriteLine("User list has been saved!\n");
        }
    }

    public void ClearUserList()
    {
        // Confirms action
        if (YesNoChoice("THIS WILL DELETE ALL USERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "User list was not cleared."))
        {
            GetUserService().ClearList();
            GetUserService().Add(GetUser());
            DrawLine();
            Console.WriteLine("User list has been cleared!\n");
        }
    }

    // Manufacturer service methods

    public void SeeManufacturerList()
    {
        _manufacturerService.DisplayAdmin();
        WaitForKey();
    }

    public void AddManufacturer()
    {
        // Creating manufacturer
        Console.WriteLine("Enter the name of the manufacturer you want to add:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the email of the manufacturer you want to add:");
        string email = Console.ReadLine();

        Manufacturer manufacturer = new Manufacturer(_manufacturerService.NewId(), name, email);

        // Confirms action
        Console.WriteLine("\n" + manufacturer);
        if (YesNoChoice("New manufacturer is above ^", "Are you sure you want to add it?", "Manufacturer was not added."))
        {
            _manufacturerService.Add(manufacturer);
            DrawLine();
            Console.WriteLine("Manufacturer was added!\n");
        }
    }

    public void EditManufacturer()
    {
        Console.WriteLine("Enter the email of the manufacturer you want to edit:");
        string email = Console.ReadLine();

        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);

        // Checks if the manufacturer exists.
        if (manufacturer == null!)
        {
            if (YesNoChoice("No manufacturer has been found with that email.", "Do you want to try again?", "No manufacturer has been removed."))
            {
                EditManufacturer();
            }
            return;
        }

        // Choose what to edit
        Console.WriteLine("\nChoose what you want to edit:");
        Console.WriteLine("1 - Edit name of manufacturer");
        Console.WriteLine("2 - Edit email of manufacturer");
        Console.WriteLine("3 - Name and email of manufacturer");
        Console.WriteLine("Anything else to cancel.");
        string choice = Console.ReadLine();

        string editedName = manufacturer.Name, editedEmail = manufacturer.Email;
        switch (choice)
        {
            case "1":
                Console.WriteLine("\nEnter the new name of the manufacturer:");
                editedName = Console.ReadLine();

                if (editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("You must input a name!", "Do you want to try again?", "Manufacturer was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the manufacturer:");
                    editedName = Console.ReadLine();
                }
                break;
            case "2":
                Console.WriteLine("\nEnter the new email of the manufacturer:");
                editedEmail = Console.ReadLine();
                while (_manufacturerService.FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Manufacturer was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new email of the manufacturer:");
                    editedEmail = Console.ReadLine();
                }
                break;
            case "3":
                Console.WriteLine("\nEnter the new name of the manufacturer:");
                editedName = Console.ReadLine();
                if (editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("You must input a name!", "Do you want to try again?", "Manufacturer was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the manufacturer:");
                    editedName = Console.ReadLine();
                }

                Console.WriteLine("\nEnter the new email of the manufacturer:");
                editedEmail = Console.ReadLine();
                while (_manufacturerService.FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if (!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Manufacturer was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new email of the manufacturer:");
                    editedEmail = Console.ReadLine();
                }
                break;
            default:
                DrawLine();
                Console.WriteLine("Manufacturer has not been edited.\n");
                return;
        }

        Manufacturer editedManufacturer = new Manufacturer(manufacturer.Id, editedName, editedEmail);

        // Confirming actions
        if (YesNoChoice("\nDetails of the edited manufacturer:\n" + editedManufacturer, "Are you sure you want to make these changes?", "Manufacturer has not been edited."))
        {
            _manufacturerService.EditById(editedManufacturer, editedManufacturer.Id);
            DrawLine();
            Console.WriteLine("Manufacturer has been edited.\n");
        }
    }

    public void RemoveManufacturer()
    {
        Console.WriteLine("Enter the email of the manufacturer you want to remove:");
        string email = Console.ReadLine();

        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);

        // Checks if the manufacturer exists.
        if (manufacturer == null!)
        {
            if (YesNoChoice("No manufacturer has been found with that email.", "Do you want to try again?", "No manufacturer has been removed."))
            {
                RemoveManufacturer();
            }
            return;
        }

        // Confirming action
        if (YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this manufacturer?", "Manufacturer was not removed."))
        {
            _manufacturerService.RemoveById(manufacturer.Id);
            DrawLine();
            Console.WriteLine("Manufacturer was removed.\n");
            if (YesNoChoice("Manufacturer was removed.\n", "Do you also want to delete medicine related to this manufacturer?", "Only manufacturer was removed."))
            {
                _medicineService.RemoveByManufacturerId(manufacturer.Id);
                DrawLine();
                Console.WriteLine("Manufacturer and related medicine were removed.\n");
            }
        }
    }

    public void SaveManufacturerList()
    {
        // Confirms action
        _manufacturerService.Display();
        if (YesNoChoice("Manufacturer list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not saved."))
        {
            _manufacturerService.SaveList(GetPath() + "manufacturers.txt");
            DrawLine();
            Console.WriteLine("Manufacturer list has been saved!\n");
        }
    }

    public void ClearManufacturerList()
    {
        // Confirms action
        if (YesNoChoice("THIS WILL DELETE ALL MANUFACTURERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not cleared."))
        {
            _manufacturerService.ClearList();
            DrawLine();

            if (YesNoChoice("Manufacturer list has been cleared!\n", "Do you also want to delete all medicine?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not cleared."))
            {
                _medicineService.ClearList();
                DrawLine();
                Console.WriteLine("All medicine and manufacturers were removed!\n");
            }
        }
    }

    // Medicine service methods

    public void SeeMedicineList()
    {
        _medicineService.DisplayAdmin();
        WaitForKey();
    }

    public void AddMedicine()
    {
        Console.WriteLine("Enter the email of the manufacturer:");
        string email = Console.ReadLine();
        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);
        int id = manufacturer == null! ? 0 : manufacturer.Id;

        if (manufacturer == null! && !YesNoChoice("No manufacturer was found with that email.", "Do you still want to continue adding the medicine?\nThe manufacturer ID will be set to 0 in this case.", "No medicine was added.")) { return; }

        Console.WriteLine("Enter the price:");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the stock ammount:");
        int stock = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the information:");
        string info = Console.ReadLine();
        Console.WriteLine("Enter all tags separated by a comma (no spaces):");
        string tags = Console.ReadLine();

        Medicine medicine = new Medicine(_medicineService.NewId(), id, price, stock, name, info, tags);

        // Confirms actions
        if (YesNoChoice($"\nHere is the medicine you created? {medicine}", "Do you want to add it?", "No medicine was added."))
        {
            _medicineService.Add(medicine);
            DrawLine();
            Console.WriteLine("Medicine was added.\n");
        }
    }

    public void EditMedicine()
    {
        Console.WriteLine("Enter the id of the medicine you want to edit:");
        int id = int.Parse(Console.ReadLine());

        Medicine medicine = _medicineService.FindById(id);
        if (medicine == null!)
        {
            if (YesNoChoice("No medicine found with that id.", "Do you want to try again?", "No medicine was edited."))
            {
                RemoveMedicine();
            }
            return;
        }

        Console.WriteLine("Choose what you want to edit:");
        Console.WriteLine("1 - Manufacturer");
        Console.WriteLine("2 - Price");
        Console.WriteLine("3 - Stock ammount");
        Console.WriteLine("4 - Name");
        Console.WriteLine("5 - Informations");
        Console.WriteLine("6 - Tags");
        Console.WriteLine("7 - Everything");
        Console.WriteLine("Anything else to cancel.");

        string editedName = medicine.Name, editedInfo = medicine.Information, email;
        double editedPrice = medicine.Price;
        int editedId = medicine.ManufacturerId, editedStock = medicine.StockAmmount;
        Manufacturer manufacturer;
        string editedTags = "";
        foreach (string tag in medicine.Tags)
        {
            editedTags += tag;
            if (medicine.Tags.Last() != tag)
            {
                editedTags += ",";
            }
        }

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter the email of the manufacturer:");
                email = Console.ReadLine();
                manufacturer = _manufacturerService.FindByEmail(email);

                while (manufacturer == null!)
                {
                    if (!YesNoChoice("No manufacturer found with that email.", "Do you want to try again?", "No medicine was edited."))
                    {
                        return;
                    }
                    email = Console.ReadLine();
                    manufacturer = _manufacturerService.FindByEmail(email);
                }
                editedId = manufacturer.Id;
                break;
            case "2":
                Console.WriteLine("Enter the new price:");
                editedPrice = double.Parse(Console.ReadLine());
                break;
            case "3":
                Console.WriteLine("Enter the new stock ammount:");
                editedStock = int.Parse(Console.ReadLine());
                break;
            case "4":
                Console.WriteLine("Enter the new name:");
                editedName = Console.ReadLine();
                break;
            case "5":
                Console.WriteLine("Enter the new informations:");
                editedInfo = Console.ReadLine();
                break;
            case "6":
                Console.WriteLine("Enter the new tags separated by a commma (no spaces):");
                editedTags = Console.ReadLine();
                break;
            case "7":
                Console.WriteLine("Enter the email of the manufacturer:");
                email = Console.ReadLine();
                manufacturer = _manufacturerService.FindByEmail(email);

                while (manufacturer == null!)
                {
                    if (!YesNoChoice("No manufacturer found with that email.", "Do you want to try again?", "No medicine was edited."))
                    {
                        return;
                    }
                    email = Console.ReadLine();
                    manufacturer = _manufacturerService.FindByEmail(email);
                }
                editedId = manufacturer.Id;
                Console.WriteLine("Enter the new price:");
                editedPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new stock ammount:");
                editedStock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new name:");
                editedName = Console.ReadLine();
                Console.WriteLine("Enter the new informations:");
                editedInfo = Console.ReadLine();
                Console.WriteLine("Enter the new tags separated by a commma (no spaces):");
                editedTags = Console.ReadLine();
                break;
            default:
                return;
        }

        // Confirms actions
        Medicine editedMedicine = new Medicine(medicine.Id, editedId, editedPrice, editedStock, editedName, editedInfo, editedTags);

        if (YesNoChoice("\nDetails of the edited medicine:\n" + editedMedicine.DescriptionForAdmin(), "Are you sure you want to make these changes?", "Medicine was not edited."))
        {
            _medicineService.EditById(editedMedicine, editedMedicine.Id);
            DrawLine();
            Console.WriteLine("Medicine was edited.\n");
        }
    }

    public void RemoveMedicine()
    {
        Console.WriteLine("Enter the id of the medicine you want to remove:");
        int id = int.Parse(Console.ReadLine());

        Medicine medicine = _medicineService.FindById(id);
        if (medicine == null!)
        {
            if (YesNoChoice("No medicine found with that id.", "Do you want to try again?", "No medicine was removed."))
            {
                RemoveMedicine();
            }
            return;
        }

        // Confirms choice
        if (YesNoChoice($"This is the medicine: {medicine}", "Are you sure you want to remove it?", "No medicine was removed."))
        {
            _medicineService.RemoveById(medicine.Id);
            DrawLine();
            Console.WriteLine("The medicine was removed.");
        }
    }

    public void SaveMedicineList()
    {
        // Confirms action
        _medicineService.Display();
        if (YesNoChoice("Medicine list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Medicine list was not saved."))
        {
            _medicineService.SaveList(GetPath() + "medicine.txt");
            DrawLine();
            Console.WriteLine("Medicine list has been saved!\n");
        }
    }

    public void ClearMedicineList()
    {
        // Confirms action
        if (YesNoChoice("THIS WILL DELETE ALL MEDICINE!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Medicine list was not cleared."))
        {
            _medicineService.ClearList();
            DrawLine();
            Console.WriteLine("Medicine list has been cleared!\n");
        }
    }

    // Order service methods

    public void SeeOrderList()
    {
        _orderService.Display();
        WaitForKey();
    }

    public void EditStatusOfOrder()
    {
        Console.WriteLine("Enter the id of the order you want to edit:");
        int id = int.Parse(Console.ReadLine());

        Order order = _orderService.FindById(id);
        if (order == null!)
        {
            if (YesNoChoice("No orders were found with that id.", "Do you want to try again?", "No orders were edited."))
            {
                RemoveOrder();
            }
            return;
        }

        Console.WriteLine("What status do you want to set?");
        Console.WriteLine("(Submitted/Sent/Received/Completed)");
        Console.WriteLine("Anything else to cancel.");
        DateTime dt = DateTime.UtcNow;
        string date = dt.ToString("d.M.yyyy");
        Order editedOrder = order.Duplicate();

        string choice = Console.ReadLine();
        switch (choice.ToLower())
        {
            case "submitted":
                editedOrder.Status = "submitted";
                for (int i = editedOrder.StatusDates.Length - 1; i > 0; i--)
                {
                    editedOrder.StatusDates[i] = null!;
                }

                for (int i = 0; i < 1; i++)
                {
                    if (editedOrder.StatusDates[i] == null!)
                    {
                        editedOrder.StatusDates[i] = date;
                    }
                }
                break;
            case "sent":
                editedOrder.Status = "sent";
                for (int i = editedOrder.StatusDates.Length - 1; i > 0; i--)
                {
                    editedOrder.StatusDates[i] = null!;
                }

                for (int i = 0; i < 2; i++)
                {
                    if (editedOrder.StatusDates[i] == null!)
                    {
                        editedOrder.StatusDates[i] = date;
                    }
                }
                break;
            case "received":
                editedOrder.Status = "received";
                for (int i = editedOrder.StatusDates.Length - 1; i > 0; i--)
                {
                    editedOrder.StatusDates[i] = null!;
                }

                for (int i = 0; i < 3; i++)
                {
                    if (editedOrder.StatusDates[i] == null!)
                    {
                        editedOrder.StatusDates[i] = date;
                    }
                }
                break;
            case "completed":
                editedOrder.Status = "completed";
                for (int i = editedOrder.StatusDates.Length - 1; i > 0; i--)
                {
                    editedOrder.StatusDates[i] = null!;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (editedOrder.StatusDates[i] == null!)
                    {
                        editedOrder.StatusDates[i] = date;
                    }
                }
                break;
            default:
                return;
        }

        // Confirms choice
        if (YesNoChoice($"\nThis is the new order:\n {order}", "Are you sure you want to save it?", "No orders were edited."))
        {
            _orderService.EditById(editedOrder, order.Id);
            DrawLine();
            Console.WriteLine("Order was edited.");
        }
    }

    public void RemoveOrder()
    {
        Console.WriteLine("Enter the id of the order you want to remove:");
        int id = int.Parse(Console.ReadLine());

        Order order = _orderService.FindById(id);
        if (order == null!)
        {
            if (YesNoChoice("No orders were found with that id.", "Do you want to try again?", "No orders were removed."))
            {
                RemoveOrder();
            }
            return;
        }

        // Confirms choice
        if (YesNoChoice($"This is the order: {order}", "Are you sure you want to remove it?", "No orders were removed."))
        {
            _orderService.RemoveById(order.Id);
            _orderDetailsService.RemoveByOrderId(order.Id);
            DrawLine();
            Console.WriteLine("The order was removed.");
        }
    }

    public void SaveOrderList()
    {
        // Confirms action
        _orderService.Display();
        if (YesNoChoice("Order list is above ^\nTHIS ALSO SAVES ORDER DETAILS!", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Order list was not saved."))
        {
            _orderService.SaveList(GetPath() + "orders.txt");
            _orderDetailsService.SaveList(GetPath() + "order_details.txt");
            DrawLine();
            Console.WriteLine("Order list has been saved!\n");
        }
    }

    public void ClearOrderList()
    {
        // Confirms action
        if (YesNoChoice("THIS WILL DELETE ALL ORDERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Order list was not cleared."))
        {
            _medicineService.ClearList();
            DrawLine();
            Console.WriteLine("Order list has been cleared!\n");
        }
    }

    // Order details service methods

    // Displays order details list with medicine names
    public void DisplayOrderDetails(OrderDetails details)
    {
        string[] medicine = new string[details.MedicineIds.Count];

        int i = 0;
        foreach (int id in details.MedicineIds)
        {
            medicine[i] = _medicineService.FindById(id).Name;
            i++;
        }
        Console.WriteLine(details.Description(medicine.ToList()));
    }

    // Displays order details with medicine names
    public void DisplayOrderDetailsList()
    {
        string[][] medicine = new string[_orderDetailsService.Count()][];
        int i = 0;
        foreach (OrderDetails details in _orderDetailsService.GetList())
        {
            medicine[i] = new string[details.MedicineIds.Count];

            int j = 0;
            foreach (int id in details.MedicineIds)
            {
                medicine[i][j] = _medicineService.FindById(id).Name;
                j++;
            }
            i++;
        }

        _orderDetailsService.DisplayWithMedicine(medicine);
        Console.WriteLine();
    }

    public void SeeOrderDetailsList()
    {
        DisplayOrderDetailsList();
        WaitForKey();
    }

    public void EditOrderDetails()
    {
        Console.WriteLine("Enter the id of the order you want to edit:");
        int id = int.Parse(Console.ReadLine());

        Order order = _orderService.FindById(id);
        if (order == null!)
        {
            if (YesNoChoice("No orders were found with that id.", "Do you want to try again?", "No orders were edited."))
            {
                EditOrderDetails();
            }
            return;
        }

        OrderDetails details = _orderDetailsService.FindByOrderId(order.Id);
        if (details == null!)
        {
            DrawLine();
            Console.WriteLine("Order has no details?");
            return;
        }

        OrderDetails editedDetails = details.Duplicate();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Choose what you want to do:");
            Console.WriteLine("1 - Display order details");
            Console.WriteLine("2 - Add medicine");
            Console.WriteLine("3 - Remove medicine");
            Console.WriteLine("4 - Edit medicine ammount");
            Console.WriteLine("Anything else to stop and go to order save menu.");
            string choice = Console.ReadLine();

            Console.WriteLine();
            int medId, ammount;
            switch (choice)
            {
                case "1":
                    DisplayOrderDetails(editedDetails);
                    WaitForKey();
                    break;
                case "2":
                    Console.WriteLine("Enter the id of the medicine you want to add:");
                    medId = int.Parse(Console.ReadLine());

                    Medicine medicine = _medicineService.FindById(medId);

                    bool addBreak = false;
                    while (medicine == null!)
                    {
                        if (!YesNoChoice("No medicine was found with that id.", "Do you want to try again?", "No medicine ids were added."))
                        {
                            addBreak = true;
                            break;
                        }
                        Console.WriteLine("Enter the id of the medicine you want to add:");
                        medId = int.Parse(Console.ReadLine());
                    }
                    if (addBreak) { break; }

                    Console.WriteLine("Enter the ammount:");
                    ammount = int.Parse(Console.ReadLine());

                    while (ammount <= 0)
                    {
                        if (!YesNoChoice("Ammount can't be negative or zero.", "Do you want to try again?", "No medicine ids were added."))
                        {
                            addBreak = true;
                            break;
                        }
                        Console.WriteLine("Enter the ammount:");
                        ammount = int.Parse(Console.ReadLine());
                    }
                    if (addBreak) { break; }

                    editedDetails.MedicineIds.Add(medId);
                    editedDetails.Ammounts.Add(ammount);
                    Console.WriteLine("\nMedicine was added!\nThese are the new order details:");
                    DisplayOrderDetails(editedDetails);
                    break;
                case "3":
                    Console.WriteLine("Enter the id of the medicine you want to remove:");
                    medId = int.Parse(Console.ReadLine());

                    bool removeBreak = false;
                    int removed = editedDetails.RemoveMedicineId(medId);
                    while (removed == 0)
                    {
                        if (!YesNoChoice("Order details don't contain medicine with that id.", "Do you want to try again?", "No medicine ids were removed."))
                        {
                            removeBreak = true;
                            break;
                        }
                        Console.WriteLine("Enter the id of the medicine you want to remove:");
                        medId = int.Parse(Console.ReadLine());
                        removed = editedDetails.RemoveMedicineId(medId);
                    }
                    if (removeBreak) { break; }

                    Console.WriteLine("\nMedicine was removed!\nThese are the new order details:");
                    DisplayOrderDetails(editedDetails);
                    break;
                case "4":
                    Console.WriteLine("Enter the medicine id for the ammount you want to edit:");
                    medId = int.Parse(Console.ReadLine());

                    bool editBreak = false;
                    int edited = editedDetails.IndexOfMedicine(medId);
                    while (edited == -1)
                    {
                        if (!YesNoChoice("Order details don't contain medicine with that id.", "Do you want to try again?", "No ammounts were edited."))
                        {
                            editBreak = true;
                            break;
                        }
                        Console.WriteLine("Enter the medicine id for the ammount you want to edit:");
                        medId = int.Parse(Console.ReadLine());
                        edited = editedDetails.IndexOfMedicine(medId);
                    }
                    if (editBreak) { break; }

                    Console.WriteLine("Enter the new ammount:");
                    ammount = int.Parse(Console.ReadLine());

                    while (ammount <= 0)
                    {
                        if (!YesNoChoice("Ammount can't be negative or zero.", "Do you want to try again?", "No medicine ids were added."))
                        {
                            editBreak = true;
                            break;
                        }
                        Console.WriteLine("Enter the ammount:");
                        ammount = int.Parse(Console.ReadLine());
                    }
                    if (editBreak) { break; }

                    editedDetails.EditAmmountByMedicineId(medId, ammount);
                    Console.WriteLine("\nMedicine ammount was edited!\nThese are the new order details:");
                    DisplayOrderDetails(editedDetails);
                    break;
                default:
                    running = false;
                    break;
            }
        }

        // Confirms actions
        DisplayOrderDetails(editedDetails);
        if (YesNoChoice("Order details are above ^", "Are you sure you want to save it?", "Order details were not saved."))
        {
            _orderDetailsService.EditById(editedDetails, details.Id);
            DrawLine();
            Console.WriteLine("Order details have been saved!\n");
        }
    }

    public void SaveOrderDetailsList()
    {
        // Confirms action
        DisplayOrderDetailsList();
        if (YesNoChoice("Order details list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Order details list was not saved."))
        {
            _orderDetailsService.SaveList(GetPath() + "order_details.txt");
            DrawLine();
            Console.WriteLine("Order details list has been saved!\n");
        }
    }
}