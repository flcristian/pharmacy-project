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

            string toSave = "";
            foreach(User user in _list)
            {
                toSave += $"{user.ToSave()}\n";
            }
            sw.Write(toSave);

            sw.Close();
        }

        public void Afisare()
        {
            foreach(User user in _list)
            {
                Console.WriteLine(user);
            }
        }

        public User FindById(int id)
        {
            foreach (User user in _list)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public User FindByEmail(string email)
        {
            foreach(User user in _list)
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }
            }

            return null;
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            foreach(User user in _list)
            {
                if(user.Email.Equals(email) && user.Password.Equals(password))
                {
                    return user;
                }
            }

            return null;
        }

        public List<User> FindByName(string name)
        {
            List<User> users = new List<User>();

            foreach(User user in _list)
            {
                if (user.Name.Equals(name))
                {
                    users.Add(user);
                }
            }

            return users;
        }

        public int Count()
        {
            return _list.Count();
        }

        public void ClearList()
        {
            _list.Clear();
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 999999);
            while(this.FindById(id) != null)
            {
                id = rnd.Next(1, 999999);
            }
            return id;
        }

        public int AddUser(User user)
        {
            // Checks if the id has already been used. Returns -1 if id is already used.
            if (this.FindById(user.Id) != null)
            {
                return -1;
            }

            // Checks if the email has been used. Returns 0 if email is already used.
            if (this.FindByEmail(user.Email) != null)
            {
                return 0;
            }

            _list.Add(user);
            return 1;
        }
    }
}
