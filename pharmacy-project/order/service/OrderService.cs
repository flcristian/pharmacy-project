﻿using System.Globalization;
using pharmacy_project.order.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.order.service
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(String path) : base(path) { }

        public OrderService(List<Order> list) : base(list) { }

        // Methods

        public List<Order> FindByCustomerId(int id)
        {
            List<Order> orders = new List<Order>();

            foreach(Order order in GetList())
            {
                if(order.CustomerId == id)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        public int DisplayByStatus(String status)
        {
            List<Order> orders = new List<Order>();
            foreach(Order order in GetList())
            {
                if (order.Status.Equals(status))
                {
                    orders.Add(order);
                }
            }

            // Returns 0 if no orders have been found.
            if(!orders.Any())
            {
                return 0;
            }

            foreach(Order order in orders)
            {
                Console.WriteLine(order);
            }
            return 1;
        }

        public int DisplayByStatusSortedByDate(String status)
        {
            List<Order> orders = new List<Order>();
            foreach (Order order in GetList())
            {
                if (order.Status.Equals(status))
                {
                    orders.Add(order);
                }
            }

            // Returns 0 if no orders have been found.
            if (!orders.Any())
            {
                return 0;
            }

            List<int> daysPassed = new List<int>();
            List<String> statuses = new List<String> { "Submitted", "Sent", "Received", "Completed" };
            foreach (Order order in orders)
            {
                String orderDate = order.StatusDates[statuses.IndexOf(status)];
                DateTime date = DateTime.ParseExact(orderDate, "d.M.yyyy", CultureInfo.InvariantCulture);
                DateTime current = DateTime.UtcNow;

                int years = current.Year - date.Year;

                int days = 0;
                if (years > 0)
                {
                    days += 365 - date.DayOfYear;
                    days += (years - 1) * 365;
                    days += current.DayOfYear;
                }
                else
                {
                    days += current.DayOfYear - date.DayOfYear;
                }

                daysPassed.Add(days);
            }

            // Using Bubble Sort with Sentinel to sort by days passed.
            int i = 0;
            bool flag = true;
            while (flag && i < orders.Count())
            {
                flag = false;
                for(int j = orders.Count() - 1; j < i; j--)
                {
                    if(daysPassed[j] < daysPassed[j - 1])
                    {
                        Order rOrder = orders[j];
                        int rDays = daysPassed[j];
                        orders[j] = orders[j - 1];
                        daysPassed[j] = daysPassed[j - 1];
                        orders[j - 1] = rOrder;
                        daysPassed[j - 1] = rDays;
                        flag = true;
                    }
                }
                i++;
            }

            foreach(Order order in orders)
            {
                Console.WriteLine(order);
            }

            return 1;
        }
    }
}
