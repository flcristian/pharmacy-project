using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.medicine.model;
using pharmacy_project.medicine.service;

namespace testing_pharmacy_project.Tests
{

    public class TestMedicineService
    {
        [Fact]
        public void FindByName_FoundMedicines_ReturnsMedicineList()
        {
            // Arrange
            string name = "name";
            Medicine m1 = new Medicine(1, 1, 1, 1, "name", "info", "tag");
            Medicine m2 = new Medicine(2, 1, 1, 1, "name", "info", "tag");
            Medicine m3 = new Medicine(3, 1, 1, 1, "name", "info", "tag");
            Medicine m4 = new Medicine(4, 1, 1, 1, "name", "info", "tag");
            List<Medicine> medicines = new List<Medicine> { m1, m2, m3, m4 };
            List<Medicine> list = new List<Medicine> { m1, m2, m3, m4 };
            MedicineService service = new MedicineService(list);

            // Act
            List<Medicine> found = service.FindByName(name);

            // Assert
            Assert.NotEmpty(found);
            Assert.Equal(medicines, found);
            Assert.Equal(4, found.Count());
        }

        [Fact]
        public void FindByName_NoMatch_ReturnsEmptyList()
        {
            // Arrange
            string name = "name";
            List<Medicine> medicines = new List<Medicine>();
            List<Medicine> list = new List<Medicine>();
            MedicineService service = new MedicineService(list);

            // Act
            List<Medicine> found = service.FindByName(name);

            // Assert
            Assert.Empty(found);
        }

        [Fact]
        public void FindByName_MultipleNamesInList_ReturnsCorrectList()
        {
            // Arrange
            string name = "name";
            Medicine m1 = new Medicine(1, 1, 1, 1, "name", "info", "tag");
            Medicine m2 = new Medicine(2, 1, 1, 1, "name", "info", "tag");
            Medicine m3 = new Medicine(3, 1, 1, 1, "name", "info", "tag");
            Medicine m4 = new Medicine(4, 1, 1, 1, "name", "info", "tag");
            Medicine m5 = new Medicine(5, 4, 2, 4, "anothername", "info", "anothertag");
            List<Medicine> medicines = new List<Medicine> { m1, m2, m3, m4 };
            List<Medicine> list = new List<Medicine> { m1, m2, m3, m4, m5 };
            MedicineService service = new MedicineService(list);

            // Act
            List<Medicine> found = service.FindByName(name);

            // Assert
            Assert.NotEmpty(found);
            Assert.Equal(4, found.Count());
            Assert.DoesNotContain(m5, found);
        }

        [Fact]
        public void RemoveByManufacturerId_NoMedicineFound_Returns0()
        {
            // Arrange
            int id = 1912;
            Medicine medicine = new Medicine(1, 1, 1, 1, "name", "info", "tag1");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int remove = service.RemoveByManufacturerId(id);

            // Arrange
            Assert.Single(service.GetList());
            Assert.Equal(0, remove);
        }

        [Fact]
        public void RemoveByManufacturerId_MedicineFound_Returns1()
        {
            // Arrange
            int id = 1912;
            Medicine medicine = new Medicine(1, id, 1, 1, "name", "info", "tag1");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int remove = service.RemoveByManufacturerId(id);

            // Arrange
            Assert.Empty(service.GetList());
            Assert.Equal(1, remove);
        }
    }
}
