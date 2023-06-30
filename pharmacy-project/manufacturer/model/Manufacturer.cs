using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.manufacturer.model
{
    public class Manufacturer : IToSave, IHasId, IHasName, IHasEmail
    {
        private int _id;
        private String _name;
        private String _email;

        // Constructors

        public Manufacturer(int id, String name, String email)
        {
            _id = id;
            _name = name;
            _email = email;
        }

        public Manufacturer(String text)
        {
            String[] data = text.Split('/');
            _id = Int32.Parse(data[0]);
            _name = data[1];
            _email = data[2];
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

        // Methods

        public override String ToString()
        {
            String desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Contact Email Adress : " + _email + "\n";

            return desc;
        }

        public String DescriptionAdmin()
        {
            String desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Name : " + _name + "\n";
            desc += "Email Adress : " + _email + "\n";

            return desc;
        }

        public String ToSave()
        {
            String save = $"{_id}/{_name}/{_email}";

            return save;
        }

        public override bool Equals(object? obj)
        {
            return _id == (obj as Manufacturer)._id && _name.Equals((obj as Manufacturer)._name) && _email.Equals((obj as Manufacturer)._email);
        }
    }
}
