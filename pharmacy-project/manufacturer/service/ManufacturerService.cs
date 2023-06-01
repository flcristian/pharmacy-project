﻿using System;
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
            _list = new List<Manufacturer>();

            this.ReadList();
        }

        // Accessors

        public List<Manufacturer> List
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
            _list = new List<Manufacturer>();
            StreamReader sr = new StreamReader("D:\\mycode\\csharp\\projects\\pharmacy-project\\pharmacy-project\\resources\\manufacturers.txt");

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
            StreamWriter sw = new StreamWriter("D:\\mycode\\csharp\\projects\\pharmacy-project\\pharmacy-project\\resources\\manufacturers.txt");

            foreach(Manufacturer manufacturer in _list)
            {
                sw.WriteLine($"{manufacturer.Id}/{manufacturer.Name}/{manufacturer.ContactEmailAdress}");
            }

            sw.Close();
        }

        public void Afisare()
        {
            foreach(Manufacturer manufacturer in _list)
            {
                Console.WriteLine(manufacturer.Description());
            }
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

        public int AddWithUniqueId(Manufacturer manufacturer)
        {
            // Returns -2, -1 or 0, manufacturer was not added.
            // Returns 1, manufacturer was added.

            // Checks if the manufacturer is a duplicate.
            List<Manufacturer> foundDupes = this.FindDuplicate(manufacturer);

            if (foundDupes.Count() > 0)
            {
                return -2;
            }

            // Checks if name is already used.
            Manufacturer foundByName = this.FindByName(manufacturer.Name);

            if (foundByName != null)
            {
                return -1;
            }

            // Checks if contact email is already used.
            Manufacturer foundByEmail = this.FindByEmail(manufacturer.ContactEmailAdress);

            if (foundByEmail != null)
            {
                return 0;
            }

            manufacturer.Id = this.NewId();
            _list.Add(manufacturer);
            return 1;
        }

        public int EditById(Manufacturer manufacturer, int id)
        {
            // Returns -1 or 0, the value remains unchanged.
            // Returns 1, the value is changed.

            // Checks if the value we want the manufacturer changed to already exists.
            List<Manufacturer> manufacturers = this.FindDuplicate(manufacturer);

            if (manufacturers.Count() > 0)
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
    }
}
