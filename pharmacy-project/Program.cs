using pharmacy_project.user.model;
using pharmacy_project.panels;
using pharmacy_project.bases.panel_base;

internal class Program
{
    private static void Main(string[] args)
    {
        String path = Directory.GetCurrentDirectory() + "\\..\\..\\..\\resources\\";
        IPanel login = new LoginPanel(path);
        login.Run();
    }
}