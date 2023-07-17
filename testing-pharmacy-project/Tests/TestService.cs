using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_pharmacy_project.Tests
{
    public class TestService
    {
        [Fact]
        public void Count_ReturnsCorrectValue()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2 };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void FindById_ValidMatch_ReturnsObject()
        {
            // Arrange
            int id = 121;
            Manufacturer expected = new Manufacturer(id, "manufacturer", "email@email.com");
            List<Manufacturer> list = new List<Manufacturer> { expected };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindById(id);

            // Arrange
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Email, actual.Email);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 121;
            List<Manufacturer> list = new List<Manufacturer>();
            IManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindById(id);

            // Arrange
            Assert.Null(actual);
        }

        [Fact]
        public void FindById_MultipleObjects_ReturnsCorrectObject()
        {
            // Arrange
            int id = 101;
            Manufacturer expected = new Manufacturer(id, "manufacturer", "email@email.com");
            Manufacturer another = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { expected, another };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindById(id);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Email, actual.Email);
            Assert.NotEqual(another.Id, actual.Id);
            Assert.NotEqual(another.Name, actual.Name);
            Assert.NotEqual(another.Email, actual.Email);
        }

        [Fact]
        public void DisplayById_ObjectNotFound_Returns0()
        {
            // Arrange
            int id = 1674;
            Manufacturer manufacturer = new Manufacturer(1241, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayById_ObjectFound_Returns1()
        {
            // Arrange
            int id = 1674;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void NewId_ReturnsUnusedId_ReturnsIdInRange()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(112341, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(281723, "manufacturer", "email@email.com");
            Manufacturer m3 = new Manufacturer(911913, "manufacturer", "email@email.com");
            Manufacturer m4 = new Manufacturer(333224, "test", "test");
            Manufacturer m5 = new Manufacturer(576765, "another", "another");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2, m3, m4, m5 };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int id = service.NewId();

            // Assert
            foreach (Manufacturer m in list)
            {
                Assert.NotEqual(m.Id, id);
            }
            Assert.InRange(id, 1, 999999);
        }

        [Fact]
        public void ClearList_RemovesAllObjects()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2 };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            service.ClearList();

            // Assert
            Assert.Empty(service.GetList());
        }

        [Fact]
        public void RemoveById_ValidMatch_RemovesObject_ReturnsTrue()
        {
            // Arrange
            int id = 81719;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int removed = service.RemoveById(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.DoesNotContain(manufacturer, service.GetList());
        }

        [Fact]
        public void RemoveById_NoMatch_DoesNotRemoveObject_ReturnsFalse()
        {
            // Arrange
            int id = 81719;
            List<Manufacturer> list = new List<Manufacturer>();
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int removed = service.RemoveById(id);

            // Assert
            Assert.Equal(0, removed);
        }

        [Fact]
        public void RemoveById_MultipleObjects_RemovesCorrectObject_ReturnsTrue()
        {
            // Arrange
            int id = 81719;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            Manufacturer another = new Manufacturer(181, "anothername", "anotheremail");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer, another };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int removed = service.RemoveById(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.DoesNotContain(manufacturer, service.GetList());
            Assert.Contains(another, service.GetList());
        }

        [Fact]
        public void Add_FoundEmail_DoesNotAdd_ReturnsNegative1()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer hasSameEmail = new Manufacturer(2, "anothername", "email");
            List<Manufacturer> list = new List<Manufacturer> { hasSameEmail };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(-1, add);
            Assert.DoesNotContain(toAdd, service.GetList());
        }

        [Fact]
        public void Add_FoundName_DoesNotAdd_ReturnsNegative2()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer hasSameName = new Manufacturer(2, "name", "anotheremail");
            List<Manufacturer> list = new List<Manufacturer> { hasSameName };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.DoesNotContain(toAdd, service.GetList());
        }

        [Fact]
        public void Add_NoMatch_AddsObject_Returns1()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            List<Manufacturer> list = new List<Manufacturer>();
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(1, add);
            Assert.Contains(toAdd, service.GetList());
        }

        [Fact]
        public void EditById_ValidMatch_ModifiesObject_Returns1()
        {
            // Arrange 
            int id = 100;
            Manufacturer modified = new Manufacturer(id, "modified", "modified");
            Manufacturer toModify = new Manufacturer(id, "modifythis", "modifythis");
            Manufacturer another = new Manufacturer(2, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { toModify, another };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int edit = service.EditById(modified, id);

            // Assert
            Assert.Equal(1, edit);
            Assert.Equal(modified, service.FindById(id));
        }

        [Fact]
        public void EditById_NoMatch_ModifiesObject_Returns1()
        {
            // Arrange
            int id = 100;
            Manufacturer modified = new Manufacturer(id, "modified", "modified");
            Manufacturer toModify = new Manufacturer(200, "modifythis", "modifythis");
            Manufacturer another = new Manufacturer(2, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { toModify, another };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            int edit = service.EditById(modified, id);

            // Assert
            Assert.Equal(0, edit);
            Assert.NotEqual(modified, service.FindById(id));
        }

        [Fact]
        public void GetList_ReturnsSameList()
        {
            // Arrange
            List<Manufacturer> list = new List<Manufacturer> { new Manufacturer(1, "name", "email") };
            IManufacturerService service = new ManufacturerService(list);

            // Act
            List<Manufacturer> returned = service.GetList();

            // Assert
            Assert.Equal(list, returned);
        }
    }
}
