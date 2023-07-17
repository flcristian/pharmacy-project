using System.Reflection;
using pharmacy_project.order_details.model;
using pharmacy_project.user.model;
using pharmacy_project.user.service;

namespace pharmacy_project.bases.panel_base;

public abstract class Panel : IPanel
{
    private UserService _userService;
    private User _user;
    private String _path;
    
    // Constructors

    public Panel(String path)
    {
        _path = path;
        _userService = new UserService(path + "users.txt");
    }

    public Panel(String path, User user)
    {
        _path = path;
        _user = user;
        _userService = new UserService(path + "users.txt");
    }

    // Miscellaneous methods

    // Duplicates user
    // Used in edit methods
    private User GetNewUserToEdit()
    {
        Type type = _user.GetType();
        String text = _user.ToSave();
        ConstructorInfo constructor = type.GetConstructor(new[] { typeof(String) });
        return (User)constructor.Invoke(new object[] { text });
    }

    // In case entered email or something is wrong
    // Ususally a "do you want to try again?" question
    protected bool YesNoChoice(String startMessage, String choiceMessage, String endMessage)
    {
        Console.WriteLine(startMessage);
        Console.WriteLine(choiceMessage + " (Y/N)");
        String wrongEmailChoice = Console.ReadLine().ToLower();
        if(wrongEmailChoice.Equals("y") || wrongEmailChoice.Equals("yes"))
        {
            return true;
        } else
        {
            DrawLine();
            Console.WriteLine(endMessage + "\n");
        }
        return false;
    }

    protected void WaitForKey()
    {
        Console.WriteLine("Enter anything to continue:");
        Console.ReadLine();
    }

    protected void DrawLine()
    {
        Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
    }
    
    protected User GetUser()
    {
        return _user;
    }

    protected String GetPath()
    {
        return _path;
    }

    protected UserService GetUserService()
    {
        return _userService;
    }

    // Panel methods

    protected void RunAccountMessage()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1 - See your account details");
        Console.WriteLine("2 - Change your name");
        Console.WriteLine("3 - Change your email");
        Console.WriteLine("4 - Change your password");
        Console.WriteLine("5 - Save changes");
    }

    protected void RunAccount()
    {
        while(true)
        {
            RunAccountMessage();
            String choice = Console.ReadLine();

            DrawLine();
            switch(choice)
            {
                case "1":
                    SeeAccountDetails();
                    break;
                case "2":
                    ChangeName();
                    break;
                case "3":
                    ChangeEmail();
                    break;
                case "4":
                    ChangePassword();
                    break;
                case "5":
                    SaveAccountDetails();
                    break;
                default:
                    return;
            }
        }
    }

    protected abstract void RunMessage();

    public abstract void Run();

    // Account methods

    private void SeeAccountDetails()
    {
        Console.WriteLine(_user);
        WaitForKey();
    }

    private void ChangeName()
    {
        Console.WriteLine("Enter the new name you want:");
        String name = Console.ReadLine();

        if(name == null! || name.Replace(" ", "").Equals(""))
        {
            if(YesNoChoice("You must imput a name!", "Do you want to try again?", "Account was not edited."))
            {
                ChangeName();
            }
            return;
        }

        User editedUser = GetNewUserToEdit();
        editedUser.Name = name;

        // Confirms actions
        bool save = YesNoChoice("\nYour new details:\n" + editedUser, "Are you sure you want to save it?", "Your account's details were not changed.");
        if(save)
        {
            _user = editedUser;
            _userService.EditById(_user, _user.Id);
            DrawLine();
            Console.WriteLine("Your account details were changed!\n");
        }
    }

    private void ChangeEmail()
    {
        Console.WriteLine("Enter the new name you want:");
        String email = Console.ReadLine();

        if(GetUserService().FindByEmail(email) != null! || email == null! || email.Replace(" ", "").Equals(""))
        {
            if(YesNoChoice("Email is invalid or already used.", "Do you want to try again?", "Account was not edited."))
            {
                ChangeEmail();
            }
            return;
        }

        User editedUser = GetNewUserToEdit();
        editedUser.Email = email;

        // Confirms actions
        bool save = YesNoChoice("\nYour new details:\n" + editedUser, "Are you sure you want to save it?", "Your account's details were not changed.");
        if(save)
        {
            _user = editedUser;
            _userService.EditById(_user, _user.Id);
            DrawLine();
            Console.WriteLine("Your account details were changed!\n");
        }
    }

    private void ChangePassword()
    {
        Console.WriteLine("Enter the new password you want:");
        String password = Console.ReadLine();

        if(password == null! || password.Replace(" ", "").Equals("") || password.Equals(_user.Password))
        {
            if(YesNoChoice("Password is invalid or unchanged.", "Do you want to try again?", "Account was not edited."))
            {
                ChangePassword();
            }
            return;
        }

        User editedUser = GetNewUserToEdit();
        editedUser.Password = password;

        // Confirms actions
        bool save = YesNoChoice("\nYour new password:\n" + password, "Are you sure you want to save it?", "Your account's password was not changed.");
        if(save)
        {
            _user = editedUser;
            _userService.EditById(_user, _user.Id);
            DrawLine();
            Console.WriteLine("Your account's password was changed!\n");
        }
    }

    private void SaveAccountDetails()
    {
        // Confirms action
        Console.WriteLine(_user);
        bool save = YesNoChoice("Your details are above ^", "Are you sure you want to save it?", "Your account's details were not changed.");
        if(save)
        {
            _userService.SaveList(GetPath() + "users.txt");
            DrawLine();
            Console.WriteLine("Your account details were changed!\n");
        }
    }
}   

