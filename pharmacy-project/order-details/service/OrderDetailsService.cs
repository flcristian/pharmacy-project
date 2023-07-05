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

        // No methods yet.
    }
}