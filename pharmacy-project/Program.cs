using pharmacy_project.medicine.model;
using pharmacy_project.order_details.model;
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

        List<int> meds = new List<int> { 1, 2, 3 };
        List<int> medAmmounts = new List<int> { 10, 6, 12 };

        OrderDetails orderDetails = new OrderDetails(1, 1, meds, medAmmounts);
        Console.WriteLine(orderDetails.Description());
    }
}