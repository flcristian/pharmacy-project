using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.user.model
{
    public class User : IToSave, IHasId, IHasName, IHasEmail, IHasPassword, IHasType
    {
        private int _id;
        private String _name;
        private String _email;
        private String _password;
        private String _type;

        // Constructors

        public User(int id, String name, String email, String password, String type)
        {
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            _type = type;
        }

        public User(String text)
        {
            String[] data = text.Split('/');

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

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public String Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }

        public String Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        // Methods

        public override String ToString()
        {
            String desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Email : " + _email + "\n";

            return desc;
        }

        public virtual String ToSave()
        {
            String save = $"{_type}/{_id}/{_name}/{_email}/{_password}";

            return save;
        }

        public override bool Equals(object? obj)
        {
            return _id == (obj as User)._id && _name.Equals((obj as User)._name) && _email.Equals((obj as User)._email) && _password.Equals((obj as User)._password) && _type.Equals((obj as User)._type);
        }
    }
}
