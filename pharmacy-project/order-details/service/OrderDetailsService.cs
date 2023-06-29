using pharmacy_project.order_details.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.order_details.service
{
    public class OrderDetailsService
    {
        private List<OrderDetails> _list;

        // Constructors

        public OrderDetailsService()
        {
            this.ReadList();
        }

        public OrderDetailsService(List<OrderDetails> list)
        {
            _list = list;
        }

        // Accessors

        public List<OrderDetails> List
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
            path += "..\\..\\..\\resources\\order_details.txt";
            StreamReader sr = new StreamReader(path);

            _list = new List<OrderDetails>();
            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                OrderDetails details = new OrderDetails(text);
                _list.Add(details);
            }
            sr.Close();
        }

        public void SaveList()
        {
            string toSave = "";
            foreach (OrderDetails details in _list)
            {
                toSave += $"{details.ToSave()}\n";
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\order_details.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(toSave);
            sw.Close();
        }

        public void Display()
        {
            if (_list.Count() == 0)
            {
                Console.WriteLine("There are no details.\n");
                return;
            }

            foreach (OrderDetails details in _list)
            {
                Console.WriteLine(details);
            }
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

        public OrderDetails FindById(int id)
        {
            foreach(OrderDetails details in _list)
            {
                if(details.Id == id)
                {
                    return details;
                }
            }

            return null;
        }

        public int AddOrderDetails(OrderDetails details)
        {
            // Checks if the id is already used. Returns 0 if id is already used.
            if (this.FindById(details.Id) != null)
            {
                return 0;
            }

            _list.Add(details);
            return 1;
        }

        public int RemoveById(int id)
        {
            OrderDetails details = this.FindById(id);
            // Checks if the details exists. Returns 0 if no.
            if (details == null)
            {
                return 0;
            }

            _list.Remove(details);
            return 1;
        }

        public int EditById(OrderDetails edited, int id)
        {
            OrderDetails details = this.FindById(id);
            // Checks if the details exists. Returns 0 if no.
            if (details == null)
            {
                return 0;
            }

            _list[_list.IndexOf(details)] = edited;
            return 1;
        }
    }
}
