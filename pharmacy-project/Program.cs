using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
using pharmacy_project.medicine.service;
using pharmacy_project.order_details.model;
using pharmacy_project.user.model;
using pharmacy_project.user.service;

internal class Program
{
    private static void Main(string[] args)
    {
        MedicineService service = new MedicineService();
        service.Afisare();

        service.AfisareAdmin();
    }
}