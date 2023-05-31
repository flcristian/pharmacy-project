using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.medicine.model
{
    public class Medicine
    {
        private int _id;
        private int _manufacturerId;
        private double _price;
        private int _stockAmmount;
        private string _name;
        private string _information;
        private List<string> _tags;

        // Constructors

        public Medicine(int id, int manufacturerId, double price, int stockAmmount, string name, string information, string tagsList)
        {
            _id = id;
            _manufacturerId = manufacturerId;
            _price = price;
            _stockAmmount = stockAmmount;
            _name = name;
            _information = information;

            _tags = new List<string>();
            string[] tagList = new string[9999];
            tagList = tagsList.Split("..");
            foreach(string tag in tagList)
            {
                _tags.Add(tag);
            }
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

        public int ManufacturerId
        {
            get { return _manufacturerId; }
            set
            {
                _manufacturerId = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public int StockAmmount
        {
            get { return _stockAmmount; }
            set
            {
                _stockAmmount = value;
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

        public string Information
        {
            get { return _information; }
            set
            {
                _information = value;
            }
        }

        public List<string> Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
            }
        }

        // Methods

        public string Description()
        {
            string desc = "";

            desc += "Name : " + _name + "\n";
            desc += "Information : " + _information + "\n";
            desc += "Price : " + _price + "$\n";
            desc += "Stock Ammount : " + _stockAmmount + "\n";
            desc += "Tags : ";

            foreach(string tag in _tags)
            {
                desc += tag + " ";
            }

            desc += "\n";

            return desc;
        }
    }
}
