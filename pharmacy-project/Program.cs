using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;
using pharmacy_project.medicine.model;
using pharmacy_project.medicine.service;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details;
using pharmacy_project.order.model;
using pharmacy_project.order.service;
using pharmacy_project.user.model;
using pharmacy_project.user.service;
using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;
using System.Runtime.Serialization;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        MedicineService service = new MedicineService();
        service.DisplayByAscendingPrice();
    }

}