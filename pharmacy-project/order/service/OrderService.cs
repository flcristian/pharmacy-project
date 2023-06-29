using pharmacy_project.order.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.order.service
{
    public class OrderService
    {
        private List<Order> _list;

        // Constructors

        public OrderService()
        {
            this.ReadList();
        }

        public OrderService(List<Order> list)
        {
            _list = list;
        }

        // Methods

        public void ReadList()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\orders.txt";
            StreamReader sr = new StreamReader(path);

            _list = new List<Order>();
            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Order order = new Order(text);
                _list.Add(order);
            }
            sr.Close();
        }

        public void SaveList()
        {
            string toSave = "";
            foreach (Order order in _list)
            {
                toSave += $"{order.ToSave()}\n";
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\orders.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(toSave);
            sw.Close();
        }

        public void Display()
        {
            if (_list.Count() == 0)
            {
                Console.WriteLine("There are no order.\n");
                return;
            }

            foreach (Order order in _list)
            {
                Console.WriteLine(order);
            }
        }

        public int DisplayById(int id)
        {
            Order order = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (order == null)
            {
                return 0;
            }

            Console.WriteLine(order);
            return 1;
        }

        public int DisplayByIdCustomer(int id)
        {
            Order order = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (order == null)
            {
                return 0;
            }

            Console.WriteLine(order.CustomerDescription());
            return 1;
        }

        public int DisplayByStatus(string status)
        {
            List<Order> orders = new List<Order>();
            foreach(Order order in _list)
            {
                if (order.Status.Equals(status))
                {
                    orders.Add(order);
                }
            }

            // Returns 0 if no orders have been found.
            if(orders.Count() == 0)
            {
                return 0;
            }

            foreach(Order order in orders)
            {
                Console.WriteLine(order);
            }
            return 1;
        }

        public int DisplayByStatusSortedByDate(string status)
        {
            List<Order> orders = new List<Order>();
            foreach (Order order in _list)
            {
                if (order.Status.Equals(status))
                {
                    orders.Add(order);
                }
            }

            // Returns 0 if no orders have been found.
            if (orders.Count() == 0)
            {
                return 0;
            }

            List<int> daysPassed = new List<int>();
            List<string> statuses = new List<string> { "Submitted", "Sent", "Received", "Completed" };
            foreach (Order order in orders)
            {
                string orderDate = order.StatusDates[statuses.IndexOf(status)];
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
        
        public Order FindById(int id)
        {
            foreach (Order order in _list)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }

            return null;
        }

        public void ClearList()
        {
            _list.Clear();
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 999999);
            while (this.FindById(id) != null)
            {
                id = rnd.Next(1, 999999);
            }
            return id;
        }

        public int Count()
        {
            return _list.Count();
        }

        public int AddOrder(Order order)
        {
            // Checks if the id is already used. Returns 0 if id is already used.
            if (this.FindById(order.Id) != null)
            {
                return 0;
            }

            _list.Add(order);
            return 1;
        }

        public int RemoveById(int id)
        {
            Order order = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (order == null)
            {
                return 0;
            }

            _list.Remove(order);
            return 1;
        }

        public int EditById(Order edited, int id)
        {
            Order order = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (order == null)
            {
                return 0;
            }

            _list[_list.IndexOf(order)] = edited;
            return 1;
        }

        public List<Order> GetList()
        {
            return _list;
        }
    }
}
