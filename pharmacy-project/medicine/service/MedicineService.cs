using pharmacy_project.medicine.model;
using pharmacy_project.abstract_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.medicine.service
{
    public class MedicineService : Service<Medicine>
    {
        // Constructors

        public MedicineService(String path) : base(path) { }

        public MedicineService(List<Medicine> list) : base(list) { }

        // Methods

        public void DisplayAdmin()
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in base.GetList())
            {
                Console.WriteLine(medicine.DescriptionForAdmin());
            }
        }

        public int DisplayById(int id)
        {
            Medicine medicine = base.FindById(id);
            // Checks if the order exists. Returns 0 if no.
            if (medicine == null)
            {
                return 0;
            }

            Console.WriteLine(medicine);
            return 1;
        }

        public void DisplayByAscendingPrice()
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            List<Medicine> list = new List<Medicine>();
            list = base.GetList().OrderBy(medicine => medicine.Price).ToList();

            foreach(Medicine medicine in list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayByDescendingPrice()
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            List<Medicine> list = new List<Medicine>();
            list = base.GetList().OrderBy(medicine => medicine.Price).Reverse().ToList();

            foreach (Medicine medicine in list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayByList(List<Medicine> list)
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayByListAdmin(List<Medicine> list)
        {
            if (!base.GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in list)
            {
                Console.WriteLine(medicine.DescriptionForAdmin());
            }
        }

        public List<Medicine> FindByName(string name)
        {
            List<Medicine> list = new List<Medicine>();
            foreach(Medicine medicine in base.GetList())
            {
                if (medicine.Name.Equals(name))
                {
                    list.Add(medicine);
                }
            }

            return list;
        }
    }
}
