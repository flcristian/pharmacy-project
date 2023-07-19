using pharmacy_project.order.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.order.service;

public interface IOrderService : IService<Order>
{
    List<Order> FindByCustomerId(int id);

    int DisplayByStatus(String status);

    int DisplayByStatusSortedByDate(String status);
}
