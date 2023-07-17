using pharmacy_project.user.model;
using pharmacy_project.panels;

internal class Program
{
    private static void Main(string[] args)
    {
        String path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\resources\\";
        /*LoginPanel login = new LoginPanel(path);
        login.Run();*/
        Customer customer = new Customer("Customer/43061/Andrei Georgescu/customer@email.com/parola/False");
        /*Customer customer = new Customer(1, "name", "email", "pass");*/
        CustomerPanel panel = new CustomerPanel(path, customer);
        panel.Run();
    }

}