using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.medicine.model
{
    public class Medicine : IHasId, IToSave
    {
        private int _id;
        private int _manufacturerId;
        private double _price;
        private int _stockAmmount;
        private string _name;
        private string _information;
        private List<string> _tags;

        // Constructors

        public Medicine(int id, int manufacturerId, double price, int stockAmmount, string name, string information, string tags)
        {
            _id = id;
            _manufacturerId = manufacturerId;
            _price = price;
            _stockAmmount = stockAmmount;
            _name = name;
            _information = information;

            _tags = new List<string>();
            string[] tagList = tags.Split(",");
            foreach(string tag in tagList)
            {
                _tags.Add(tag);
            }
        }

        public Medicine(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _manufacturerId = Int32.Parse(data[1]);
            _price = Double.Parse(data[2]);
            _stockAmmount = Int32.Parse(data[3]);
            _name = data[4];
            _information = data[5];

            _tags = new List<string>();
            string[] tags = data[6].Split(",");
            foreach (string tag in tags)
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

        public override string ToString()
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

        public string DescriptionForAdmin()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Manufacturer Id : " + _manufacturerId + "\n";
            desc += "Name : " + _name + "\n";
            desc += "Information : " + _information + "\n";
            desc += "Price : " + _price + "$\n";
            desc += "Stock Ammount : " + _stockAmmount + "\n";
            desc += "Tags : ";

            foreach (string tag in _tags)
            {
                desc += tag + " ";
            }

            desc += "\n";

            return desc;
        }

        public string ToSave()
        {
            string save = $"{_id}/{_manufacturerId}/{_price}/{_stockAmmount}/{_name}/{_information}/";

            foreach(string tag in _tags)
            {
                save += tag;

                if(_tags.IndexOf(tag) != _tags.Count() - 1)
                {
                    save += ",";
                }
            }

            return save;
        }  
    }
}
