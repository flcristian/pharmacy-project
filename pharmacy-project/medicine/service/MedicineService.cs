using pharmacy_project.medicine.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.medicine.service
{
    public class MedicineService
    {
        private List<Medicine> _list;

        // Constructors

        public MedicineService()
        {
            this.ReadList();
        }

        public MedicineService(List<Medicine> list)
        {
            _list = list;
        }

        // Accessors

        public List<Medicine> List
        {
            get { return _list; }
            set
            {
                _list = value;
            }
        }

        // Methods

        public void ReadList()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\medicine.txt";
            StreamReader sr = new StreamReader(path);

            _list = new List<Medicine>();
            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Medicine medicine = new Medicine(text);
                _list.Add(medicine);
            }
            sr.Close();
        }

        public void SaveList()
        {
            string toSave = "";
            foreach(Medicine medicine in _list)
            {
                toSave += $"{medicine.ToSave()}\n";
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\medicine.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(toSave);
            sw.Close();
        }

        public void Display()
        {
            if(_list.Count() == 0)
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach(Medicine medicine in _list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayAdmin()
        {
            if (_list.Count() == 0)
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in _list)
            {
                Console.WriteLine(medicine.DescriptionForAdmin());
            }
        }

        public int DisplayById(int id)
        {
            Medicine medicine = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (medicine == null)
            {
                return 0;
            }

            Console.WriteLine(medicine);
            return 1;
        }

        public Medicine FindById(int id)
        {
            foreach(Medicine medicine in _list)
            {
                if(medicine.Id == id)
                {
                    return medicine;
                }
            }

            return null;
        }

        public void ClearList()
        {
            _list.Clear();
        }

        public int NewId()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 999999);
            while(this.FindById(id) != null)
            {
                id = rnd.Next(1, 999999);
            }
            return id;
        }

        public int Count()
        {
            return _list.Count();
        }

        public int AddMedicine(Medicine medicine)
        {
            // Checks if the id is already used. Returns 0 if id is already used.
            if(this.FindById(medicine.Id) != null)
            {
                return 0;
            }

            _list.Add(medicine);
            return 1;
        }

        public int RemoveById(int id)
        {
            Medicine medicine = this.FindById(id);
            // Checks if the medicine exists. Returns 0 if no.
            if (medicine == null)
            {
                return 0;
            }

            _list.Remove(medicine);
            return 1;
        }

        public int EditById(Medicine edited, int id)
        {
            Medicine medicine = this.FindById(id);
            // Checks if the medicine exists. Returns 0 if no.
            if (medicine == null)
            {
                return 0;
            }

            _list[_list.IndexOf(medicine)] = edited;
            return 1;
        }
    }
}
