using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.order.model
{
    public class Order : IToSave, IHasId, IDuplicable<Order>
    {
        private int _id;
        private int _customerId;
        private String _status;
        private String[] _statusDates;

        // ORDER STATUSES = Submitted / Sent / Received / Completed

        // Constructors

        public Order(int id, int customerId, String status, String[] statusDates)
        {
            _id = id;
            _customerId = customerId;
            _status = status;
            _statusDates = statusDates;
        }

        public Order(int id, int customerId, String status)
        {
            _id = id;
            _customerId = customerId;
            _status = status;

            _statusDates = new String[4];
            _statusDates[0] = DateTime.UtcNow.ToString("dd.MM.yyyy");
        }

        public Order(String text)
        {
            String[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _customerId = Int32.Parse(data[1]);
            _status = data[2];

            _statusDates = new String[4];
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

        public String Status
        {
            get { return _status; }
            set
            {
                _status = value;
            }
        }

        public String[] StatusDates
        {
            get { return _statusDates; }
            set
            {
                value.CopyTo(StatusDates, 0);
            }
        }

        // Methods

        public override String ToString()
        {
            String desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Customer Id : " + _customerId + "\n";
            desc += "Status : " + _status + "\n";

            String[] statuses = new String[4] { "Submitted", "Sent", "Received", "Completed" };
            int i = 0;
            while (i < 4 && _statusDates[i] != null!)
            {
                desc += statuses[i] + " : " + _statusDates[i] + "\n";
                i++;
            }

            return desc;
        }

        public String CustomerDescription()
        {
            String desc = "";

            desc += "Id : " + _id + "\n";
            desc += "Status : " + _status + "\n";

            String[] statuses = new String[4] { "Submitted", "Sent", "Received", "Completed" };
            int i = 0;
            while (i < 4 && _statusDates[i] != null!)
            {
                desc += statuses[i] + " : " + _statusDates[i] + "\n";
                i++;
            }

            return desc;
        }

        public String ToSave()
        {
            String save = $"{_id}/{_customerId}/{_status}/";

            int i = 0, count = _statusDates.ToList().Count();
            while (i < count && _statusDates[i] != null!)
            {
                save += $"{_statusDates[i]}";
                if (i + 1 < count && _statusDates[i + 1] != null!)
                {
                    save += "/";
                }
                Console.WriteLine(_statusDates[i]);
                i++;
            }

            return save;
        }

        public override bool Equals(object? obj)
        {
            return _id == (obj as Order)._id && _customerId == (obj as Order)._customerId && _status.Equals((obj as Order)._status) && _statusDates.Equals((obj as Order)._statusDates);
        }

        public Order Duplicate()
        {
            return new Order(_id, _customerId, _status, _statusDates);
        }
    }
}
