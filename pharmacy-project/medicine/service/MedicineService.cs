using pharmacy_project.medicine.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.medicine.service
{
    public class MedicineService : Service<Medicine>, IMedicineService
    {
        // Constructors

        public MedicineService(String path) : base(path) { }

        public MedicineService(List<Medicine> list) : base(list) { }

        // Methods

        public void DisplayAdmin()
        {
            if (!GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in GetList())
            {
                Console.WriteLine(medicine.DescriptionForAdmin());
            }
        }

        public void DisplayByAscendingPrice()
        {
            if (!GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            List<Medicine> list = new List<Medicine>();
            list = GetList().OrderBy(medicine => medicine.Price).ToList();

            foreach(Medicine medicine in list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayByDescendingPrice()
        {
            if (!GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            List<Medicine> list = new List<Medicine>();
            list = GetList().OrderBy(medicine => medicine.Price).Reverse().ToList();

            foreach (Medicine medicine in list)
            {
                Console.WriteLine(medicine);
            }
        }

        public void DisplayByList(List<Medicine> list)
        {
            if (!GetList().Any())
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
            if (!GetList().Any())
            {
                Console.WriteLine("There are no medicine.\n");
                return;
            }

            foreach (Medicine medicine in list)
            {
                Console.WriteLine(medicine.DescriptionForAdmin());
            }
        }

        public List<Medicine> FindByName(String name)
        {
            List<Medicine> list = new List<Medicine>();
            foreach(Medicine medicine in GetList())
            {
                if (medicine.Name.Equals(name))
                {
                    list.Add(medicine);
                }
            }

            return list;
        }

        public int RemoveByManufacturerId(int id)
        {
            int count = 0;
            for(int i = 0; i < Count(); i++)
            {
                if(GetList()[i].ManufacturerId == id)
                {
                    GetList().RemoveAt(i);
                    count++;
                }
            }

            // Checks if any medicine are from this manufacturers. Returns 0 if not
            if(count == 0)
            {
                return 0;
            }
            return 1;
        }
    }
}
