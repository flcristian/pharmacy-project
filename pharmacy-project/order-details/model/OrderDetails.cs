using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.order_details.model
{
    public class OrderDetails
    {
        private int _id;
        private int _orderId;
        private List<int> _medicineIds;
        private List<int> _ammounts;

        // Constructors

        public OrderDetails(int id, int orderId, List<int> medicineIds, List<int> ammounts)
        {
            _id = id;
            _orderId = orderId;
            _medicineIds = medicineIds;
            _ammounts = ammounts;
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
        
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                _orderId = value;
            }
        }

        public List<int> MedicineIds
        {
            get { return _medicineIds; }
            set
            {
                _medicineIds = value;
            }
        }

        public List<int> Ammounts
        {
            get { return _ammounts; }
            set
            {
                _ammounts = value;
            }
        }

        // Methods

        public string Description()
        {
            // This description is mainly for admins.

            string desc = "";

            if(_medicineIds.Count() > 0)
            {
                desc += $"Order Id : {_orderId}\n";
                
                foreach(int id in _medicineIds)
                {
                    desc += $"Id x Ammount : {id} x {_ammounts[_medicineIds.IndexOf(id)]}\n";
                }
            }
            else
            {
                desc = $"Order id {_orderId} is empty.";
            }

            return desc;
        }
    }
}
