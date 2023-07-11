using pharmacy_project.interfaces;
using pharmacy_project.order_details.model;
using pharmacy_project.abstract_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_project.order_details.service
{
    public class OrderDetailsService : Service<OrderDetails>
    {
        // Constructors

        public OrderDetailsService(String path) : base(path) { }

        public OrderDetailsService(List<OrderDetails> list) : base(list) { }

        // Methods

        public void DisplayWithMedicine(String[][] medicine)
        {
            if (!GetList().Any())
            {
                Console.WriteLine("There are no manufacturers.\n");
                return;
            }

            int i = 0;
            foreach (OrderDetails details in GetList())
            {
                Console.WriteLine(details.Description(medicine[i].ToList()));
                i++;
            }
        }

        public OrderDetails FindByOrderId(int id)
        {
            foreach (OrderDetails details in GetList())
            {
                if (details.OrderId == id)
                {
                    return details;
                }
            }
            return null;
        }

        public int RemoveByOrderId(int id)
        {
            OrderDetails details = FindByOrderId(id);

            // Checks if the order exists
            if(details == null!)
            {
                return 0;
            }

            RemoveById(details.Id);
            return 1;
        }
    }
}