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
    }
}
