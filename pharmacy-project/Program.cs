﻿using pharmacy_project.manufacturer.model;
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
        Admin admin = new Admin("Admin/126133/Catalin Marinescu/admin@email.com/parola");
        /*Customer customer = new Customer(1, "name", "email", "pass");*/
        AdminPanel panel = new AdminPanel(path, admin);
        panel.Run();
    }

}