using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.manufacturer.model
{
    public class Manufacturer
    {
        private int _id;
        private string _name;
        private string _contactEmailAdress;

        // Constructors

        public Manufacturer(int id, string name, string contactEmailAdress)
        {
            _id = id;
            _name = name;
            _contactEmailAdress = contactEmailAdress;
        }

        public Manufacturer(string text)
        {
            string[] data = text.Split('/');
            _id = Int32.Parse(data[0]);
            _name = data[1];
            _contactEmailAdress = data[2];
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

        public string ContactEmailAdress
        {
            get { return _contactEmailAdress; }
            set
            {
                _contactEmailAdress = value;
            }
        }

        // Methods

        public override string ToString()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Contact Email Adress : " + _contactEmailAdress + "\n";

            return desc;
        }

        public string DescriptionAdmin()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Name : " + _name + "\n";
            desc += "Contact Email Adress : " + _contactEmailAdress + "\n";

            return desc;
        }

        public string ToSave()
        {
            string save = $"{_id}/{_name}/{_contactEmailAdress}";

            return save;
        }
    }
}
