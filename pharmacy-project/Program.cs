using pharmacy_project.user.model;
using pharmacy_project.panels;
using pharmacy_project.bases.panel_base;

internal class Program
{
    private static void Main(string[] args)
    {
        String path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\resources\\";
        Customer customer = new Customer("Customer/43061/Andrei Georgescu/customer@email.com/parola/False");
        IPanel panel = new CustomerPanel(path, customer);
        /*IPanel login = new LoginPanel(path);*/
        panel.Run();
    }

}