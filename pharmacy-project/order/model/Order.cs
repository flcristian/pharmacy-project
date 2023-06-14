using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.order.model
{
    public class Order
    {
        private int _id;
        private int _customerId;
        private string _status;

        // Constructors
        public Order(int id, int customerId, string status)
        {
            _id = id;
            _customerId = customerId;
            _status = status;
        }

        public Order(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _customerId = Int32.Parse(data[1]);
            _status = data[2];
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

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }

        // Methods

        public override string ToString()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Customer Id : " + _customerId + "\n";
            desc += "Status : " + _status + "\n";

            return desc;
        }

        public string ToSave()
        {
            string save = $"{_id}/{_customerId}/{_status}";

            return save;
        }
    }
}
