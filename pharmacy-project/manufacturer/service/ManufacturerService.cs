using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.manufacturer.model;

namespace pharmacy_project.manufacturer.service
{
    public class ManufacturerService
    {
        private List<Manufacturer> _list;

        // Constructors

        public ManufacturerService(List<Manufacturer> list)
        {
            _list = list;
        }

        public ManufacturerService()
        {
            this.ReadList();
        }

        // Methods

        public void ReadList()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\manufacturers.txt";
            StreamReader sr = new StreamReader(path);

            _list = new List<Manufacturer>();
            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Manufacturer manufacturer = new Manufacturer(text);

                _list.Add(manufacturer);
            }

            sr.Close();
        }

        public void SaveList()
        {
            string toSave = "";
            foreach(Manufacturer manufacturer in _list)
            {
                toSave += $"{manufacturer.ToSave()}\n";
            }

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "..\\..\\..\\resources\\manufacturers.txt";

            StreamWriter sw = new StreamWriter(path);
            sw.Write(toSave);
            sw.Close();
        }

        public void Display()
        {
            if (!_list.Any())
            {
                Console.WriteLine("There are no manufacturers.\n");
                return;
            }

            foreach (Manufacturer manufacturer in _list)
            {
                Console.WriteLine(manufacturer);
            }
        }

        public void DisplayAdmin()
        {
            if (!_list.Any())
            {
                Console.WriteLine("There are no manufacturers.\n");
                return;
            }

            foreach (Manufacturer manufacturer in _list)
            {
                Console.WriteLine(manufacturer.DescriptionAdmin());
            }
        }

        public int DisplayById(int id)
        {
            Manufacturer manufacturer = this.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (manufacturer == null)
            {
                return 0;
            }

            Console.WriteLine(manufacturer);
            return 1;
        }

        public int Count()
        {
            return _list.Count();
        }

        public Manufacturer FindById(int id)
        {
            foreach(Manufacturer manufacturer in _list)
            {
                if(manufacturer.Id == id)
                {
                    return manufacturer;
                }
            }

            return null;
        }

        public Manufacturer FindByName(string name)
        {
            foreach (Manufacturer manufacturer in _list)
            {
                if (manufacturer.Name.Equals(name))
                {
                    return manufacturer;
                }
            }

            return null;
        }

        public Manufacturer FindByEmail(string email)
        {
            foreach (Manufacturer manufacturer in _list)
            {
                if (manufacturer.ContactEmailAdress.Equals(email))
                {
                    return manufacturer;
                }
            }

            return null;
        }

        public List<Manufacturer> FindDuplicate(Manufacturer manufacturer)
        {
            List<Manufacturer> list = new List<Manufacturer>();

            foreach(Manufacturer toCompare in _list)
            {
                if (toCompare.Name.Equals(manufacturer.Name) && toCompare.ContactEmailAdress.Equals(manufacturer.ContactEmailAdress) && toCompare.Id != manufacturer.Id) 
                {
                    list.Add(toCompare);
                }
            }

            return list;
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

        public void ClearList()
        {
            _list.Clear();
        }

        public bool RemoveById(int id)
        {
            Manufacturer manufacturer = this.FindById(id);

            if(manufacturer != null)
            {
                _list.Remove(manufacturer);

                return true;
            }

            return false;
        }

        public int Add(Manufacturer manufacturer)
        {
            // Returns -3, -2, -1 or 0, manufacturer was not added.
            // Returns 1, manufacturer was added.

            // Checks if the manufacturer is a duplicate.
            List<Manufacturer> foundDupes = this.FindDuplicate(manufacturer);

            if (foundDupes.Count() > 0)
            {
                return -3;
            }

            // Checks if name is already used.
            Manufacturer foundByName = this.FindByName(manufacturer.Name);

            if(foundByName != null)
            {
                return -2;
            }

            // Checks if contact email is already used.
            Manufacturer foundByEmail = this.FindByEmail(manufacturer.ContactEmailAdress);

            if (foundByEmail != null)
            {
                return -1;
            }

            // Checks if id is already used.
            Manufacturer foundById = this.FindById(manufacturer.Id);
            
            if(foundById != null)
            {
                return 0;
            }

            _list.Add(manufacturer);
            return 1;
        }

        public int EditById(Manufacturer manufacturer, int id)
        {
            // Returns -3, -2, -1 or 0, the value remains unmodified.
            // Returns 1, the value is changed.

            // Checks if the manufacturer is a duplicate.
            List<Manufacturer> foundDupes = this.FindDuplicate(manufacturer);

            if (foundDupes.Any())
            {
                return -3;
            }

            // Checks if name is already used.
            Manufacturer foundByName = this.FindByName(manufacturer.Name);

            if (foundByName != null && foundByName.Id != manufacturer.Id)
            {
                return -2;
            }

            // Checks if contact email is already used.
            Manufacturer foundByEmail = this.FindByEmail(manufacturer.ContactEmailAdress);

            if (foundByEmail != null && foundByEmail.Id != manufacturer.Id)
            {
                return -1;
            }

            // Checks if the manufacturer is unchanged.
            Manufacturer found = this.FindById(id);

            if(found.Name.Equals(manufacturer.Name) && found.ContactEmailAdress.Equals(manufacturer.ContactEmailAdress))
            {
                return 0;
            }

            _list[_list.IndexOf(found)] = manufacturer;
            return 1;
        }

        public List<Manufacturer> GetList()
        {
            return _list;
        }
    }
}
