using pharmacy_project.order_details.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.order_details.service;

public interface IOrderDetailsService : IService<OrderDetails>
{
    void DisplayWithMedicine(String[][] medicine);

    OrderDetails FindByOrderId(int id);

    int RemoveByOrderId(int id);
}
