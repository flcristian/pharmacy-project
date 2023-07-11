using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
using pharmacy_project.medicine.service;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details;
using pharmacy_project.order.model;
using pharmacy_project.order.service;
using pharmacy_project.abstract_classes;
using pharmacy_project.user.model;
using pharmacy_project.user.service;
using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Runtime.Serialization;
using System.Linq.Expressions;
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