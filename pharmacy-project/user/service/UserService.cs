using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.user.model;
using pharmacy_project.abstract_classes;

namespace pharmacy_project.user.service
{
    public class UserService : Service<User>
    {
        // Constructors

        public UserService(String path) : base(path) { }

        public UserService(List<User> list) : base(list) { }

        // Methods

        public int DisplayById(int id)
        {
            User user = base.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (user == null!)
            {
                return 0;
            }

            Console.WriteLine(user);
            return 1;
        }

        public User FindByEmail(String email)
        {
            foreach(User user in base.GetList())
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }
            }

            return null;
        }

        public User FindByEmailAndPassword(String email, String password)
        {
            foreach(User user in base.GetList())
            {
                if(user.Email.Equals(email) && user.Password.Equals(password))
                {
                    return user;
                }
            }

            return null;
        }

        public List<User> FindByName(String name)
        {
            List<User> users = new List<User>();

            foreach(User user in base.GetList())
            {
                if (user.Name.Equals(name))
                {
                    users.Add(user);
                }
            }

            return users;
        }

        public bool IsAdmin(User user)
        {
            if(user.Type.Equals("Admin"))
            {
                return true;
            }
            return false;
        }

        public int RemoveByEmail(String email)
        {
            User user = this.FindByEmail(email);

            // Checks if the user exists. Returns 0 if no.
            if (user == null!)
            {
                return 0;
            }

            base.RemoveById(user.Id);
            return 1;
        }

        public override int Add(User user)
        {
            // Checks if id is already used.
            if(base.FindById(user.Id) != null!)
            {
                return -1;
            }

            // Checks if email is already used.
            if(this.FindByEmail(user.Email) != null!)
            {
                return 0;
            }

            base.Add(user);
            return 1;
        }
    }
}
