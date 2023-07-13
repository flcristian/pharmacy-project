using pharmacy_project.medicine.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.medicine.service;

public interface IMedicineService : IService<Medicine>
{
    void DisplayAdmin();

    void DisplayByAscendingPrice();

    void DisplayByDescendingPrice();

    void DisplayByList(List<Medicine> list);

    void DisplayByListAdmin(List<Medicine> list);

    List<Medicine> FindByName(String name);

    int RemoveByManufacturerId(int id);
}
