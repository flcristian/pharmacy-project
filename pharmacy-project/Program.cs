using pharmacy_project.medicine.model;
using pharmacy_project.user.model;

internal class Program
{
    private static void Main(string[] args)
    {
        Admin admin = new Admin(1, "name", "email", "password");
        admin.Name = "another name";

        Console.WriteLine(admin.Description());

        Medicine medicine = new Medicine(1, 1, 69.00, 102, "Paduden", "Medicament forte", "tag1..dog..cat..wtf");
        Console.WriteLine(medicine.Description());
    }
}