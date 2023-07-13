using pharmacy_project.order_details.model;

namespace pharmacy_project.panels.admin;

public interface IAdminPanel
{
    void RunManufacturersMessage();

    void RunManufacturers();

    void RunMedicineMessage();

    void RunMedicine();

    void RunOrdersMessage();

    void RunOrders();

    void RunOrderDetailsMessage();

    void RunOrderDetails();

    void RunUsersMessage();

    void RunUsers();

    // User service methods

    void SeeCustomerList();

    void SeeAdminList();

    void EditCustomer();

    void RemoveCustomer();

    void BlockCustomer();

    void UnblockCustomer();

    void MakeCustomerAdmin();

    void RemoveAdmin();

    void SaveUserList();

    void ClearUserList();

    // Manufacturer service methods

    void SeeManufacturerList();

    void AddManufacturer();

    void EditManufacturer();

    void RemoveManufacturer();

    void SaveManufacturerList();

    void ClearManufacturerList();

    // Medicine service methods

    void SeeMedicineList();

    void AddMedicine();

    void EditMedicine();

    void RemoveMedicine();

    void SaveMedicineList();

    void ClearMedicineList();

    // Order service methods

    void SeeOrderList();

    void EditStatusOfOrder();

    void RemoveOrder();

    void SaveOrderList();

    void ClearOrderList();

    void DisplayOrderDetails(OrderDetails details);

    void DisplayOrderDetailsList();

    void SeeOrderDetailsList();

    void EditOrderDetails();

    void SaveOrderDetailsList();
}
