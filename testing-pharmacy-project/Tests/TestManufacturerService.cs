using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using pharmacy_project.manufacturer.model;
using pharmacy_project.manufacturer.service;

namespace testing_pharmacy_project.Tests
{
    public class TestManufacturerService
    {
        [Fact]
        public void Count_ReturnsCorrectValue()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2 };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void FindById_ValidMatch_ReturnsManufacturer()
        {
            // Arrange
            int id = 121;
            Manufacturer expected = new Manufacturer(id, "manufacturer", "email@email.com");
            List<Manufacturer> list = new List<Manufacturer> { expected };
            ManufacturerService service = new ManufacturerService(list);

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
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindById(id);

            // Arrange
            Assert.Null(actual);    
        }

        [Fact]
        public void FindById_MultipleManufacturers_ReturnsCorrectManufacturer()
        {
            // Arrange
            int id = 101;
            Manufacturer expected = new Manufacturer(id, "manufacturer", "email@email.com");
            Manufacturer another = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { expected, another };
            ManufacturerService service = new ManufacturerService(list);

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
        public void FindByEmail_ValidMatch_ReturnsManufacturer()
        {
            // Arrange
            string email = "thisemail@gog.com";
            Manufacturer expected = new Manufacturer(1, "name", email);
            List<Manufacturer> list = new List<Manufacturer> { expected };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByEmail(email);

            // Arrange
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Email, actual.Email);
        }

        [Fact]
        public void FindByEmail_NoMatch_ReturnsNull()
        {
            // Arrange
            string email = "thisemail@gog.com";
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByEmail(email);

            // Arrange
            Assert.Null(actual);
        }

        [Fact]
        public void FindByEmail_MultipleManufacturers_ReturnsCorrectManufacturer()
        {
            // Arrange
            string email = "thisemail@gog.com";
            Manufacturer expected = new Manufacturer(1, "name", email);
            Manufacturer another = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { expected, another };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByEmail(email);

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
        public void FindByName_ValidMatch_ReturnsManufacturer()
        {
            // Arrange
            string name = "manuname";
            Manufacturer expected = new Manufacturer(1, name, "thisemail@gog.com");
            List<Manufacturer> list = new List<Manufacturer> { expected };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByName(name);

            // Arrange
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Email, actual.Email);
        }

        [Fact]
        public void FindByName_NoMatch_ReturnsNull()
        {
            // Arrange
            string name = "manuname";
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByName(name);

            // Arrange
            Assert.Null(actual);
        }

        [Fact]
        public void FindByName_MultipleManufacturers_ReturnsCorrectManufacturer()
        {
            // Arrange
            string name = "manuname";
            Manufacturer expected = new Manufacturer(1, name, "thisemail@gog.com");
            Manufacturer another = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { expected, another };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            Manufacturer actual = service.FindByName(name);

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
        public void DisplayById_ManufacturerNotFound_Returns0()
        {
            // Arrange
            int id = 1674;
            Manufacturer manufacturer = new Manufacturer(1241, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayById_ManufacturerFound_Returns1()
        {
            // Arrange
            int id = 1674;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            ManufacturerService service = new ManufacturerService(list);

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
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int id = service.NewId();

            // Assert
            foreach(Manufacturer m in list)
            {
                Assert.NotEqual(m.Id, id);
            }
            Assert.InRange(id, 1, 999999);
        }

        [Fact]
        public void ClearList_RemovesAllManufacturers()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "anotherone", "site@domain.com");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2 };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            service.ClearList();

            // Assert
            Assert.Empty(service.GetList());
        }

        [Fact]
        public void RemoveById_ValidMatch_RemovesManufacturer_ReturnsTrue()
        {
            // Arrange
            int id = 81719;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int removed = service.RemoveById(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.DoesNotContain(manufacturer, service.GetList());
        }

        [Fact]
        public void RemoveById_NoMatch_DoesNotRemoveManufacturer_ReturnsFalse()
        {
            // Arrange
            int id = 81719;
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int removed = service.RemoveById(id);

            // Assert
            Assert.Equal(0, removed);
        }

        [Fact]
        public void RemoveById_MultipleManufacturers_RemovesCorrectManufacturer_ReturnsTrue()
        {
            // Arrange
            int id = 81719;
            Manufacturer manufacturer = new Manufacturer(id, "name", "email");
            Manufacturer another = new Manufacturer(181, "anothername", "anotheremail");
            List<Manufacturer> list = new List<Manufacturer> { manufacturer, another };
            ManufacturerService service = new ManufacturerService(list);

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
            ManufacturerService service = new ManufacturerService(list);

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
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.DoesNotContain(toAdd, service.GetList());
        }

        [Fact]
        public void Add_NoMatch_AddsManufacturer_Returns1()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(1, add);
            Assert.Contains(toAdd, service.GetList());
        }

        [Fact]
        public void EditById_NoMatch_ModifiedManufacturer_Returns1()
        {
            // Arrange
            int id = 100;
            Manufacturer modified = new Manufacturer(id, "modified", "modified");
            Manufacturer toModify = new Manufacturer(id, "modifythis", "modifythis");
            Manufacturer another = new Manufacturer(2, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { toModify, another };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int edit = service.EditById(modified, id);

            // Assert
            Assert.Equal(1, edit);
            Assert.Equal(modified, service.FindById(id));
        }

        [Fact]
        public void GetList_ReturnsSameList()
        {
            // Arrange
            List<Manufacturer> list = new List<Manufacturer> { new Manufacturer(1,"name","email") };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            List<Manufacturer> returned = service.GetList();

            // Assert
            Assert.Equal(list, returned);
        }
    }
}
