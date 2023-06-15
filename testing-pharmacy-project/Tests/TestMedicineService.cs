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
        public void FindById_ValidMatch_ReturnsMedicine()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            Medicine found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(0, found.ManufacturerId);
            Assert.Equal(1, found.Price);
            Assert.Equal(1, found.StockAmmount);
            Assert.Equal("name", found.Name);
            Assert.Equal("info", found.Information);

            List<string> tags = new List<string> { "tag1", "tag2" };
            Assert.Equal(tags, found.Tags);

            Assert.Equal(medicine, found);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Assert
            int id = 1674;
            List<Medicine> list = new List<Medicine>();
            MedicineService service = new MedicineService(list);

            // Act
            Medicine found = service.FindById(id);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindById_MultipleMedicine_ReturnsCorrectMedicine()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            Medicine another = new Medicine(71, 1, 85, 189, "afuj", "agawj", "tag91");
            List<Medicine> list = new List<Medicine> { medicine, another };
            MedicineService service = new MedicineService(list);

            // Act
            Medicine found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(0, found.ManufacturerId);
            Assert.Equal(1, found.Price);
            Assert.Equal(1, found.StockAmmount);
            Assert.Equal("name", found.Name);
            Assert.Equal("info", found.Information);

            List<string> tags = new List<string> { "tag1", "tag2" };
            Assert.Equal(tags, found.Tags);

            Assert.Equal(medicine, found);
            Assert.NotEqual(another, found);
        }

        [Fact]
        public void DisplayById_MedicineNotFound_Returns0()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(189, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayById_MedicineFound_Returns1()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void ClearList_EmptiesList()
        {
            // Arrange
            List<Medicine> list = new List<Medicine>
            {
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag")
            };
            MedicineService service = new MedicineService(list);

            // Act
            service.ClearList();

            // Assert
            Assert.Empty(service.List);
            Assert.Equal(0, service.Count());
        }

        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            // Arrange
            List<Medicine> list = new List<Medicine>
            {
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(1,1,1,1,"name","info","tag")
            };
            MedicineService service = new MedicineService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(4, count);
        }

        [Fact]
        public void NewId_ReturnsUnusedId_ReturnsIdInRange()
        {
            // Arrange
            List<Medicine> list = new List<Medicine>
            {
                new Medicine(1,1,1,1,"name","info","tag"),
                new Medicine(2,1,1,1,"name","info","tag"),
                new Medicine(3,1,1,1,"name","info","tag"),
                new Medicine(4,1,1,1,"name","info","tag")
            };
            MedicineService service = new MedicineService(list);

            // Act
            int newId = service.NewId();

            // Assert
            Assert.InRange(newId, 1, 999999);
            foreach(Medicine medicine in service.List)
            {
                Assert.NotEqual(newId, medicine.Id);
            }
        }

        [Fact]
        public void AddMedicine_IdAlreadyUsed_DoesNotAddMedicine_Returns0()
        {
            // Assert
            int id = 1674;
            Medicine toAdd = new Medicine(id, 2, 2, 2, "anothername", "someinfo", "atag");
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int add = service.AddMedicine(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.Equal(1, service.Count());
            Assert.DoesNotContain(toAdd, service.List);
        }

        [Fact]
        public void AddMedicine_IdNotUsed_AddsMedicine_Returns1()
        {
            // Assert
            int id = 1674;
            Medicine toAdd = new Medicine(id, 2, 2, 2, "anothername", "someinfo", "atag");
            Medicine medicine = new Medicine(41, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int add = service.AddMedicine(toAdd);

            // Assert
            Assert.Equal(1, add);
            Assert.Equal(2, service.Count());
            Assert.Contains(toAdd, service.List);
        }

        [Fact]
        public void RemoveById_MedicineNotFound_DoesNotRemoveMedicine_Returns0()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(189, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(0, remove);
            Assert.Equal(1, service.Count());
            Assert.Contains(medicine, service.List);
        }

        [Fact]
        public void RemoveById_MedicineFound_RemovesMedicine_Returns1()
        {
            // Assert
            int id = 1674;
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(1, remove);
            Assert.Empty(service.List);
            Assert.Equal(0, service.Count());
            Assert.DoesNotContain(medicine, service.List);
        }

        [Fact]
        public void EditById_MedicineNotFound_DoesNotEditMedicine_Returns0()
        {
            // Assert
            int id = 1674;
            Medicine edited = new Medicine(id, 0, 1, 1, "newname", "newinfo", "newtag");
            Medicine medicine = new Medicine(189, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int edit = service.EditById(edited, id);

            // Assert
            Assert.Equal(0, edit);
            Assert.DoesNotContain(edited, service.List);
            Assert.NotEqual(service.FindById(189), edited);
        }

        [Fact]
        public void EditById_MedicineFound_EditsMedicine_Returns1()
        {
            // Assert
            int id = 1674;
            Medicine edited = new Medicine(id, 0, 1, 1, "newname", "newinfo", "newtag");
            Medicine medicine = new Medicine(id, 0, 1, 1, "name", "info", "tag1,tag2");
            List<Medicine> list = new List<Medicine> { medicine };
            MedicineService service = new MedicineService(list);

            // Act
            int edit = service.EditById(edited, id);

            // Assert
            Assert.Equal(1, edit);
            Assert.Contains(edited, service.List);
            Assert.Equal(service.FindById(id), edited);
        }
    }
}
