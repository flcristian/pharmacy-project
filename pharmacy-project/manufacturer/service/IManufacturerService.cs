using pharmacy_project.manufacturer.model;
using pharmacy_project.bases.service_base;

namespace pharmacy_project.manufacturer.service;

public interface IManufacturerService : IService<Manufacturer>
{
    void DisplayAdmin();

    Manufacturer FindByName(String name);

    Manufacturer FindByEmail(String email);
}
