using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.user.model;

namespace pharmacy_project.user.service
{
    public class UserService
    {
        private List<User> _list;

        // Constructors

        public UserService()
        {
            this.ReadList();
        }

        public UserService(List<User> list)
        {
            _list = list;
        }

        // Accessors

        public List<User> List
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
            _list = new List<User>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\projects\\pharmacy-project\\pharmacy-project\\resources\\users.txt");

            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                string type = text.Split('/')[0];

                switch (type)
                {
                    case "Admin":
                        Admin admin = new Admin(text);
                        _list.Add(admin);
                        break;
                    case "Customer":
                        Customer customer = new Customer(text);
                        _list.Add(customer);
                        break;
                    default:
                        break;
                }
            }
            sr.Close();
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\projects\\pharmacy-project\\pharmacy-project\\resources\\users.txt");
            
            foreach(User user in _list)
            {
                switch (user.Type)
                {
                    case "Admin":
                        Admin admin = user as Admin;
                        sw.WriteLine($"{admin.Type}/{admin.Id}/{admin.Name}/{admin.Email}/{admin.Password}");
                        break;
                    case "Customer":
                        Customer customer = user as Customer;
                        sw.WriteLine($"{customer.Type}/{customer.Id}/{customer.Name}/{customer.Email}/{customer.Password}/{customer.Locked}");
                        break;
                    default:
                        break;
                }
            }
            sw.Close();
        }

        public void Afisare()
        {
            foreach(User user in _list)
            {
                string desc = $"{user.Type.ToUpper()}\n";
                switch (user.Type)
                {
                    case "Admin":
                        Admin admin = user as Admin;
                        desc += admin.AdminDescription();
                        break;
                    case "Customer":
                        Customer customer = user as Customer;
                        desc += customer.CustomerDescription();
                        if (customer.Locked)
                        {
                            desc += "USER IS BANNED\n";
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine(desc);
            }
        }
    }
}
