using System;
using System.Collections.Generic;
using System.Globalization;
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
        private string[] _statusDates;

        // ORDER STATUSES = Submitted / Sent / Received / Completed

        // Constructors
        public Order(int id, int customerId, string status)
        {
            _id = id;
            _customerId = customerId;
            _status = status;

            _statusDates = new string[4];
            _statusDates[0] = DateTime.UtcNow.ToString("dd.MM.yyyy");
        }

        public Order(string text)
        {
            string[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _customerId = Int32.Parse(data[1]);
            _status = data[2];

            _statusDates = new string[4];
            int j = 0;
            for(int i = 3; i < data.Count(); i = i + 1, j = j + 1)
            {
                _statusDates[j] = data[i];
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

        public string[] StatusDates
        {
            get { return _statusDates; }
            set
            {
                value.CopyTo(StatusDates, 0);
            }
        }

        // Methods

        public override string ToString()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Customer Id : " + _customerId + "\n";
            desc += "Status : " + _status + "\n";

            string[] statuses = new string[4] { "Submitted", "Sent", "Received", "Completed" };
            int i = 0;
            while (i < 4 && _statusDates[i] != null)
            {
                desc += statuses[i] + " : " + _statusDates[i] + "\n";
                i++;
            }

            return desc;
        }

        public string CustomerDescription()
        {
            string desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Status : " + _status + "\n";

            string[] statuses = new string[4] { "Submitted", "Sent", "Received", "Completed" };
            int i = 0;
            while (i < 4 && _statusDates[i] != null)
            {
                desc += statuses[i] + " : " + _statusDates[i] + "\n";
                i++;
            }

            return desc;
        }

        public string ToSave()
        {
            string save = $"{_id}/{_customerId}/{_status}/";

            int i = 0;
            while (_statusDates[i] != null && i < 4)
            {
                save += $"{_statusDates[i]}";
                if (i + 1 < 4 && _statusDates[i + 1] != null)
                {
                    save += "/";
                }
            }

            return save;
        }
    }
}
