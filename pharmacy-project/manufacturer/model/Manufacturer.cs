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

        // Accesors

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

        public string Description()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Contact Email Adress : " + _contactEmailAdress + "\n";

            return desc;
        }
    }
}
