using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.interfaces;

namespace pharmacy_project.order_details.model
{
    public class OrderDetails : IHasId, IToSave, IDuplicable<OrderDetails>
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

        public OrderDetails(String text)
        {
            String[] data = text.Split('/');

            _id = Int32.Parse(data[0]);
            _orderId = Int32.Parse(data[1]);

            _medicineIds = new List<int>();
            _ammounts = new List<int>();
            for(int i = 2; i < data.Count(); i += 2)
            {
                _medicineIds.Add(Int32.Parse(data[i]));
                _ammounts.Add(Int32.Parse(data[i + 1]));
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

        public override String ToString()
        {
            String desc = "";

            if(_medicineIds.Any())
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

        public String Description(List<String> medicine)
        {
            String desc = "";

            if(_medicineIds.Any())
            {
                desc += $"Order Id : {_orderId}\n";
                foreach(int id in _medicineIds)
                {
                    int index = _medicineIds.IndexOf(id);
                    desc += $"Id - Name x Ammount : {id} - {medicine[index]} x {_ammounts[index]}\n";
                }
            }
            else
            {
                desc = $"Order id {_orderId} is empty.";
            }

            return desc;
        }

        public String ToSave()
        {
            String save = $"{_id}/{_orderId}/";

            for(int i = 0; i < _medicineIds.Count(); i++)
            {
                save += $"{_medicineIds[i]}/{_ammounts[i]}";

                if(i != _medicineIds.Count() - 1)
                {
                    save += "/";
                }
            }

            return save;
        }

        public override bool Equals(object? obj)
        {
            return _id == (obj as OrderDetails)._id && _orderId == (obj as OrderDetails)._orderId && _medicineIds.Equals((obj as OrderDetails)._medicineIds) && _ammounts.Equals((obj as OrderDetails)._ammounts);
        }
        
        public OrderDetails Duplicate()
        {
            return new OrderDetails(ToSave());
        }

        public int IndexOfMedicine(int id)
        {
            return MedicineIds.IndexOf(id);
        }

        public int RemoveMedicineId(int id)
        {
            int index = IndexOfMedicine(id);
            // Checks if medicine exists
            if (index == -1)
            {
                return 0;
            }

            MedicineIds.RemoveAt(index);
            Ammounts.RemoveAt(index);
            return 1;
        }

        public int EditAmmountByMedicineId(int id, int ammount)
        {
            int index = IndexOfMedicine(id);
            // Checks if medicine exists
            if (index == -1)
            {
                return 0;
            }

            Ammounts[index] = ammount;
            return 1;
        }
    }
}
