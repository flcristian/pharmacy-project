using pharmacy_project.order.model;
using System;
using System.Collections.Generic;
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

        // Accessors

        public List<Order> List
        {
            get { return _list; }
            set
            {
                _list = value;
            }
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

        // TODO : Find by order status.

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
    }
}
