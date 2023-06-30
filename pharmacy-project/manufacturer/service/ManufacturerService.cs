using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.abstract_classes;
using pharmacy_project.manufacturer.model;

namespace pharmacy_project.manufacturer.service
{
    public class ManufacturerService : Service<Manufacturer>
    {
        // Constructors

        public ManufacturerService(String path) : base(path) { }

        public ManufacturerService(List<Manufacturer> list) : base(list) { }

        // Methods

        public void DisplayAdmin()
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no manufacturers.\n");
                return;
            }

            foreach (Manufacturer manufacturer in base.GetList())
            {
                Console.WriteLine(manufacturer.DescriptionAdmin());
            }
        }

        public int DisplayById(int id)
        {
            Manufacturer manufacturer = base.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (manufacturer == null)
            {
                return 0;
            }

            Console.WriteLine(manufacturer);
            return 1;
        }

        public override int Add(Manufacturer manufacturer)
        {
            // Checks if the email is already used
            if(this.FindByEmail(manufacturer.ContactEmailAdress) != null)
            {
                return -1;
            }

            // Checks if the name is already used
            if(this.FindByName(manufacturer.Name) != null)
            {
                return 0;
            }

            base.Add(manufacturer);
            return 1;
        }

        public Manufacturer FindByName(String name)
        {
            foreach(Manufacturer manufacturer in base.GetList())
            {
                if (manufacturer.Name.Equals(name))
                {
                    return manufacturer;
                }
            }

            return null;
        }

        public Manufacturer FindByEmail(String email)
        {
            foreach (Manufacturer manufacturer in base.GetList())
            {
                if (manufacturer.ContactEmailAdress.Equals(email))
                {
                    return manufacturer;
                }
            }

            return null;
        }
    }
}
