using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.user.model
{
    public class User
    {
        private int _id;
        private string _name;
        private string _email;
        private string _password;
        private string _type;

        // Constructors

        public User(int id, string name, string email, string password, string type)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            _type = type;
        }

        public User(string text)
        {
            string[] data = text.Split('/');

            _type = data[0];
            _id = Int32.Parse(data[1]);
            _name = data[2];
            _email = data[3];
            _password = data[4];
        }

        // Accessors

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        // Methods

        public string Description()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Email : " + _email + "\n";

            return desc;
        }
    }
}
