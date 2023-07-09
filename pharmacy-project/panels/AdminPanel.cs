using pharmacy_project.abstract_classes;
using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
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

    private void RunManufacturersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See manufacturer list");
        Console.WriteLine("2 - Add manufacturer");
        Console.WriteLine("3 - Edit manufacturer");
        Console.WriteLine("4 - Remove manufacturer");
        Console.WriteLine("5 - Save manufacturer list");
        Console.WriteLine("6 - Clear manufacturer list");
    }

    private void RunManufacturers()
    {
        while(true)
        {
            RunManufacturersMessage();
            String choice = Console.ReadLine();

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

    private void RunMedicineMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See medicine list");
        Console.WriteLine("2 - Add medicine");
        Console.WriteLine("3 - Edit medicine");
        Console.WriteLine("4 - Remove medicine");
        Console.WriteLine("5 - Save medicine list");
        Console.WriteLine("6 - Clear medicine list");
    }

    private void RunMedicine()
    {
        while(true)
        {
            RunMedicineMessage();
            String choice = Console.ReadLine();

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

    private void RunOrdersMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See order list");
        Console.WriteLine("2 - Edit status of order");
        Console.WriteLine("3 - Remove order");
        Console.WriteLine("4 - Save order list");
        Console.WriteLine("5 - Clear order list");
    }

    private void RunOrders()
    {
        while(true)
        {
            RunOrdersMessage();
            String choice = Console.ReadLine();

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
        while(true)
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

        while(true)
        {
            RunMessage();
            String choice = Console.ReadLine();

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
                    if(!YesNoChoice("You must input a name!", "Do you want to try again?", "Account was not edited."))
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
                    if(!YesNoChoice("You must input a name!", "Do you want to try again?", "Account was not edited."))
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
        if(YesNoChoice("\nDetails of the edited customer:\n" + editedCustomer, "Are you sure you want to make these changes?", "Customer has not been edited."))
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
        if(YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this customer?", "Customer was not removed."))
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
        if(YesNoChoice("This is the customer you want to block ^", "Are you sure you want to block this customer?", "Customer was not blocked"))
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
        if(YesNoChoice("This is the customer you want to unblock ^", "Are you sure you want to unblock this customer?", "Customer was not unblocked"))
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
                MakeCustomerAdmin();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(customer);
        if(YesNoChoice("This is the customer you want to make admin ^", "Are you sure you want to make this customer admin?", "Customer was not assigned as admin."))
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
                RemoveAdmin();
            }
            return;
        }

        // Confirms action
        Console.WriteLine(admin);
        if(YesNoChoice("This is the admin you want to remove ^", "Are you sure you want to remove this admin?", "Admin was not removed."))
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
        if(YesNoChoice("User list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "User list was not saved."))
        {
            GetUserService().SaveList(GetPath() + "users.txt");
            DrawLine();
            Console.WriteLine("User list has been saved!\n");
        }
    }

    private void ClearUserList()
    {
        // Confirms action
        if(YesNoChoice("THIS WILL DELETE ALL USERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "User list was not cleared."))
        {
            GetUserService().ClearList();
            GetUserService().Add(GetUser());
            DrawLine();
            Console.WriteLine("User list has been cleared!\n");
        }
    }

    // Manufacturer service methods

    private void SeeManufacturerList()
    {
        _manufacturerService.DisplayAdmin();
        WaitForKey();
    }

    private void AddManufacturer()
    {
        // Creating manufacturer
        Console.WriteLine("Enter the name of the manufacturer you want to add:");
        String name = Console.ReadLine();
        Console.WriteLine("Enter the email of the manufacturer you want to add:");
        String email = Console.ReadLine();

        Manufacturer manufacturer = new Manufacturer(_manufacturerService.NewId(), name, email);

        // Confirms action
        Console.WriteLine("\n" + manufacturer);
        if(YesNoChoice("New manufacturer is above ^", "Are you sure you want to add it?", "Manufacturer was not added."))
        {
            _manufacturerService.Add(manufacturer);
            DrawLine();
            Console.WriteLine("Manufacturer was added!\n");
        }
    }

    private void EditManufacturer()
    {
        Console.WriteLine("Enter the email of the manufacturer you want to edit:");
        String email = Console.ReadLine();

        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);

        // Checks if the manufacturer exists.
        if(manufacturer == null!)
        {
            if(YesNoChoice("No manufacturer has been found with that email.", "Do you want to try again?", "No manufacturer has been removed."))
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
        String choice = Console.ReadLine();

        String editedName = manufacturer.Name, editedEmail = manufacturer.Email;
        switch(choice)
        {
            case "1":
                Console.WriteLine("\nEnter the new name of the manufacturer:");
                editedName = Console.ReadLine();

                if(editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("You must input a name!", "Do you want to try again?", "Manufacturer was not edited."))
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
                while(_manufacturerService.FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Manufacturer was not edited."))
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
                if(editedName == null! || editedName.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("You must input a name!", "Do you want to try again?", "Manufacturer was not edited."))
                    {
                        return;
                    }
                    Console.WriteLine("\nEnter the new name of the manufacturer:");
                    editedName = Console.ReadLine();
                }

                Console.WriteLine("\nEnter the new email of the manufacturer:");
                editedEmail = Console.ReadLine();
                while(_manufacturerService.FindByEmail(editedEmail) != null! || editedEmail == null! || editedEmail.Replace(" ", "").Equals(""))
                {
                    if(!YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Manufacturer was not edited."))
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
        if(YesNoChoice("\nDetails of the edited manufacturer:\n" + editedManufacturer, "Are you sure you want to make these changes?", "Manufacturer has not been edited."))
        {
            _manufacturerService.EditById(editedManufacturer, editedManufacturer.Id);
            DrawLine();
            Console.WriteLine("Manufacturer has been edited.\n");
        }
    }

    private void RemoveManufacturer()
    {
        Console.WriteLine("Enter the email of the manufacturer you want to remove:");
        String email = Console.ReadLine();

        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);

        // Checks if the manufacturer exists.
        if(manufacturer == null!)
        {
            if(YesNoChoice("No manufacturer has been found with that email.", "Do you want to try again?", "No manufacturer has been removed."))
            {
                RemoveManufacturer();
            }
            return;
        }

        // Confirming action
        if(YesNoChoice("THIS CAN NOT BE UNDONE!", "Are you sure you want to remove this manufacturer?", "Manufacturer was not removed."))
        {
            _manufacturerService.RemoveById(manufacturer.Id);
            DrawLine();
            Console.WriteLine("Manufacturer was removed.\n");
            if(YesNoChoice("Manufacturer was removed.\n", "Do you also want to delete medicine related to this manufacturer?", "Only manufacturer was removed."))
            {
                _medicineService.RemoveByManufacturerId(manufacturer.Id);
                DrawLine();
                Console.WriteLine("Manufacturer and related medicine were removed.\n");
            }
        }
    }

    private void SaveManufacturerList()
    {
        // Confirms action
        _manufacturerService.Display();
        if(YesNoChoice("Manufacturer list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not saved."))
        {
            _manufacturerService.SaveList(GetPath() + "manufacturers.txt");
            DrawLine();
            Console.WriteLine("Manufacturer list has been saved!\n");
        }
    }

    private void ClearManufacturerList()
    {
        // Confirms action
        if(YesNoChoice("THIS WILL DELETE ALL MANUFACTURERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not cleared."))
        {
            _manufacturerService.ClearList();
            DrawLine();

            if(YesNoChoice("Manufacturer list has been cleared!\n", "Do you also want to delete all medicine?\nTHIS CAN NOT BE UNDONE!", "Manufacturer list was not cleared."))
            {
                _medicineService.ClearList();
                DrawLine();
                Console.WriteLine("All medicine and manufacturers were removed!\n");
            }
        }
    }

    // Medicine service methods

    private void SeeMedicineList()
    {
        _medicineService.DisplayAdmin();
        WaitForKey();
    }

    private void AddMedicine()
    {
        Console.WriteLine("Enter the email of the manufacturer:");
        String email = Console.ReadLine();
        Manufacturer manufacturer = _manufacturerService.FindByEmail(email);
        int id = manufacturer == null! ? 0 : manufacturer.Id;

        if(manufacturer == null! && !YesNoChoice("No manufacturer was found with that email.", "Do you still want to continue adding the medicine?\nThe manufacturer ID will be set to 0 in this case.", "No medicine was added.")){return;}

        Console.WriteLine("Enter the price:");
        Double price = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the stock ammount:");
        int stock = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter the name:");
        String name = Console.ReadLine();
        Console.WriteLine("Enter the information:");
        String info = Console.ReadLine();
        Console.WriteLine("Enter all tags separated by a comma (no spaces):");
        String tags = Console.ReadLine();

        Medicine medicine = new Medicine(_medicineService.NewId(), id, price, stock, name, info, tags);

        // Confirms actions
        if(YesNoChoice($"\nHere is the medicine you created? {medicine}", "Do you want to add it?", "No medicine was added."))
        {
            _medicineService.Add(medicine);
            DrawLine();
            Console.WriteLine("Medicine was added.\n");
        }
    }

    private void EditMedicine()
    {
        Console.WriteLine("Enter the id of the medicine you want to edit:");
        int id = Int32.Parse(Console.ReadLine());

        Medicine medicine = _medicineService.FindById(id);
        if(medicine == null!)
        {
            if(YesNoChoice("No medicine found with that id.", "Do you want to try again?", "No medicine was edited."))
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

        String editedName = medicine.Name, editedInfo = medicine.Information, email;
        Double editedPrice = medicine.Price;
        int editedId = medicine.ManufacturerId, editedStock = medicine.StockAmmount;
        Manufacturer manufacturer;
        String editedTags = "";
        foreach(String tag in medicine.Tags)
        {
            editedTags += tag;
            if(medicine.Tags.Last() != tag)
            {
                editedTags += ",";
            }
        }

        String choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter the email of the manufacturer:");
                email = Console.ReadLine();
                manufacturer = _manufacturerService.FindByEmail(email);

                while(manufacturer == null!)
                {
                    if(!YesNoChoice("No manufacturer found with that email.", "Do you want to try again?", "No medicine was edited."))
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
                editedPrice = Double.Parse(Console.ReadLine());
                break;
            case "3":
                Console.WriteLine("Enter the new stock ammount:");
                editedStock = Int32.Parse(Console.ReadLine());
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

                while(manufacturer == null!)
                {
                    if(!YesNoChoice("No manufacturer found with that email.", "Do you want to try again?", "No medicine was edited."))
                    {
                        return;
                    }
                    email = Console.ReadLine();
                    manufacturer = _manufacturerService.FindByEmail(email);
                }
                editedId = manufacturer.Id;
                Console.WriteLine("Enter the new price:");
                editedPrice = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new stock ammount:");
                editedStock = Int32.Parse(Console.ReadLine());
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

        if(YesNoChoice("\nDetails of the edited medicine:\n" + editedMedicine.DescriptionForAdmin(), "Are you sure you want to make these changes?", "Medicine was not edited."))
        {
            _medicineService.EditById(editedMedicine, editedMedicine.Id);
            DrawLine();
            Console.WriteLine("Medicine was edited.\n");
        }
    }

    private void RemoveMedicine()
    {
        Console.WriteLine("Enter the id of the medicine you want to remove:");
        int id = Int32.Parse(Console.ReadLine());

        Medicine medicine = _medicineService.FindById(id);
        if(medicine == null!)
        {
            if(YesNoChoice("No medicine found with that id.", "Do you want to try again?", "No medicine was removed."))
            {
                RemoveMedicine();
            }
            return;
        }

        // Confirms choice
        if(YesNoChoice($"This is the medicine: {medicine}", "Are you sure you want to remove it?", "No medicine was removed."))
        {
            _medicineService.RemoveById(medicine.Id);
            DrawLine();
            Console.WriteLine("The medicine was removed.");
        }
    }

    private void SaveMedicineList()
    {
        // Confirms action
        _medicineService.Display();
        if(YesNoChoice("Medicine list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Medicine list was not saved."))
        {
            _medicineService.SaveList(GetPath() + "medicine.txt");
            DrawLine();
            Console.WriteLine("Medicine list has been saved!\n");
        }
    }

    private void ClearMedicineList()
    {
        // Confirms action
        if(YesNoChoice("THIS WILL DELETE ALL MEDICINE!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Medicine list was not cleared."))
        {
            _medicineService.ClearList();
            DrawLine();
            Console.WriteLine("Medicine list has been cleared!\n");
        }
    }

    // Order service methods

    private void SeeOrderList()
    {
        _orderService.Display();
        WaitForKey();
    }

    private void EditStatusOfOrder()
    {
        Console.WriteLine("Enter the id of the order you want to edit:");
        int id = Int32.Parse(Console.ReadLine());

        Order order = _orderService.FindById(id);
        if(order == null!)
        {
            if(YesNoChoice("No orders were found with that id.", "Do you want to try again?", "No orders were edited."))
            {
                RemoveOrder();
            }
            return;
        }

        Console.WriteLine("What status do you want to set?");
        Console.WriteLine("(Submitted/Sent/Received/Completed)");
        DateTime dt = DateTime.UtcNow;
        String date = dt.ToString("d.M.yyyy");
        Order editedOrder = order.Duplicate();

        String choice = Console.ReadLine();
        switch(choice.ToLower())
        {
            case "submitted":
                editedOrder.Status = "submitted";
                for (int i = editedOrder.StatusDates.Length - 1; i > 0; i--)
                {
                    editedOrder.StatusDates[i] = null!;
                }

                for(int i = 0; i < 1; i++)
                {
                    if(editedOrder.StatusDates[i] == null!)
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

                for(int i = 0; i < 2; i++)
                {
                    if(editedOrder.StatusDates[i] == null!)
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

                for(int i = 0; i < 3; i++)
                {
                    if(editedOrder.StatusDates[i] == null!)
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

                for(int i = 0; i < 4; i++)
                {
                    if(editedOrder.StatusDates[i] == null!)
                    {
                        editedOrder.StatusDates[i] = date;
                    }
                }
                break;
            default:
                return;
        }

        // Confirms choice
        if(YesNoChoice($"\nThis is the new order:\n {order}", "Are you sure you want to save it?", "No orders were edited."))
        {
            _orderService.EditById(editedOrder, order.Id);
            DrawLine();
            Console.WriteLine("Order was edited.");
        }
    }

    private void RemoveOrder()
    {
        Console.WriteLine("Enter the id of the order you want to remove:");
        int id = Int32.Parse(Console.ReadLine());

        Order order = _orderService.FindById(id);
        if(order == null!)
        {
            if(YesNoChoice("No orders were found with that id.", "Do you want to try again?", "No orders were removed."))
            {
                RemoveOrder();
            }
            return;
        }

        // Confirms choice
        if(YesNoChoice($"This is the order: {order}", "Are you sure you want to remove it?", "No orders were removed."))
        {
            _orderService.RemoveById(order.Id);
            DrawLine();
            Console.WriteLine("The order was removed.");
        }
    }

    private void SaveOrderList()
    {
        // Confirms action
        _orderService.Display();
        if(YesNoChoice("Order list is above ^", "Are you sure you want to save it?\nTHIS CAN NOT BE UNDONE!", "Order list was not saved."))
        {
            _orderService.SaveList(GetPath() + "orders.txt");
            DrawLine();
            Console.WriteLine("Order list has been saved!\n");
        }
    }

    private void ClearOrderList()
    {
        // Confirms action
        if(YesNoChoice("THIS WILL DELETE ALL ORDERS!", "Are you sure you want to clear the list?\nTHIS CAN NOT BE UNDONE!", "Order list was not cleared."))
        {
            _medicineService.ClearList();
            DrawLine();
            Console.WriteLine("Order list has been cleared!\n");
        }
    }

    // Order details service methods

    private void SeeOrderDetailsList()
    {

    }

    private void EditOrderDetails()
    {

    }

    private void SaveOrderDetailsList()
    {

    }
}