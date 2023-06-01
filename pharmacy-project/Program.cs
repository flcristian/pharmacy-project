using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
using pharmacy_project.order_details.model;
using pharmacy_project.user.model;

internal class Program
{
    private static void Main(string[] args)
    {
        ManufacturerService manufacturerService = new ManufacturerService();
        manufacturerService.Afisare();
    }
}