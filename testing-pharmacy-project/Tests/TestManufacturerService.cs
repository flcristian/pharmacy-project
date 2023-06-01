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
        public void GetCount_ReturnsCorrectValue()
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
            Assert.NotEqual(another.Id, actual.Id);
            Assert.NotEqual(another.Name, actual.Name);
            Assert.NotEqual(another.ContactEmailAdress, actual.ContactEmailAdress);
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
            Assert.NotEqual(another.Id, actual.Id);
            Assert.NotEqual(another.Name, actual.Name);
            Assert.NotEqual(another.ContactEmailAdress, actual.ContactEmailAdress);
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
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
            Assert.Equal(expected.ContactEmailAdress, actual.ContactEmailAdress);
            Assert.NotEqual(another.Id, actual.Id);
            Assert.NotEqual(another.Name, actual.Name);
            Assert.NotEqual(another.ContactEmailAdress, actual.ContactEmailAdress);
        }

        [Fact]
        public void FindDuplicate_ValidMatches_ReturnsList()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "manufacturer", "email@email.com");
            Manufacturer m3 = new Manufacturer(3, "manufacturer", "email@email.com");
            Manufacturer m4 = new Manufacturer(4, "test", "test");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2, m3, m4 };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            List<Manufacturer> found = service.FindDuplicate(m1);

            // Assert
            Assert.NotEmpty(found);
            foreach(Manufacturer m in found)
            {
                Assert.NotEqual(m1.Id, m.Id);
                Assert.Equal(m1.Name, m.Name);
                Assert.Equal(m1.ContactEmailAdress, m.ContactEmailAdress);
                Assert.NotEqual(m4.Name, m.Name);
                Assert.NotEqual(m4.ContactEmailAdress, m.ContactEmailAdress);
            }
        }

        [Fact]
        public void FindDuplicate_NoMatch_ReturnsEmptyList()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            List<Manufacturer> found = service.FindDuplicate(m1);

            // Assert
            Assert.Empty(found);
        }

        [Fact]
        public void FindDuplicate_MultipleManufacturers_ReturnsCorrectList()
        {
            // Arrange
            Manufacturer m1 = new Manufacturer(1, "manufacturer", "email@email.com");
            Manufacturer m2 = new Manufacturer(2, "manufacturer", "email@email.com");
            Manufacturer m3 = new Manufacturer(3, "manufacturer", "email@email.com");
            Manufacturer m4 = new Manufacturer(4, "test", "test");
            Manufacturer m5 = new Manufacturer(5, "another", "another");
            List<Manufacturer> list = new List<Manufacturer> { m1, m2, m3, m4, m5 };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            List<Manufacturer> found = service.FindDuplicate(m1);

            // Assert
            Assert.NotEmpty(found);
            foreach (Manufacturer m in found)
            {
                Assert.NotEqual(m1.Id, m.Id);
                Assert.Equal(m1.Name, m.Name);
                Assert.Equal(m1.ContactEmailAdress, m.ContactEmailAdress);
                Assert.NotEqual(m4.Name, m.Name);
                Assert.NotEqual(m4.ContactEmailAdress, m.ContactEmailAdress);
                Assert.NotEqual(m5.Name, m.Name);
                Assert.NotEqual(m5.ContactEmailAdress, m.ContactEmailAdress);
            }
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
            Assert.Empty(service.List);
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
            bool removed = service.RemoveById(id);

            // Assert
            Assert.True(removed);
            Assert.DoesNotContain(manufacturer, service.List);
        }

        [Fact]
        public void RemoveById_NoMatch_DoesNotRemoveManufacturer_ReturnsFalse()
        {
            // Arrange
            int id = 81719;
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            bool removed = service.RemoveById(id);

            // Assert
            Assert.False(removed);
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
            bool removed = service.RemoveById(id);

            // Assert
            Assert.True(removed);
            Assert.DoesNotContain(manufacturer, service.List);
            Assert.Contains(another, service.List);
        }

        [Fact]
        public void Add_FoundDupe_DoesNotAdd_ReturnsNegative3()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer dupe = new Manufacturer(2, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { dupe };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(-3, add);
            Assert.DoesNotContain(toAdd, service.List);
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
            Assert.Equal(-2, add);
            Assert.DoesNotContain(toAdd, service.List);
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
            Assert.DoesNotContain(toAdd, service.List);
        }

        [Fact]
        public void Add_FoundId_DoesNotAdd_Returns0()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer dupe = new Manufacturer(1, "nafasme", "emaasfil");
            List<Manufacturer> list = new List<Manufacturer> { dupe };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.DoesNotContain(toAdd, service.List);
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
            Assert.Contains(toAdd, service.List);
        }

        [Fact]
        public void AddWithUniqueId_FoundDupe_DoesNotAdd_ReturnsNegative2()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer dupe = new Manufacturer(2, "name", "email");
            List<Manufacturer> list = new List<Manufacturer> { dupe };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.AddWithUniqueId(toAdd);

            // Assert
            Assert.Equal(-2, add);
            Assert.DoesNotContain(toAdd, service.List);
        }

        [Fact]
        public void AddWithUniqueId_FoundName_DoesNotAdd_ReturnsNegative1()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer hasSameName = new Manufacturer(2, "name", "anotheremail");
            List<Manufacturer> list = new List<Manufacturer> { hasSameName };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.AddWithUniqueId(toAdd);

            // Assert
            Assert.Equal(-1, add);
            Assert.DoesNotContain(toAdd, service.List);
        }

        [Fact]
        public void AddWithUniqueId_FoundEmail_DoesNotAdd_Returns0()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            Manufacturer hasSameEmail = new Manufacturer(2, "anothername", "email");
            List<Manufacturer> list = new List<Manufacturer> { hasSameEmail };
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.AddWithUniqueId(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.DoesNotContain(toAdd, service.List);
        }

        [Fact]
        public void AddWithUniqueId_NoMatch_AddsManufacturer_Returns1()
        {
            // Arrange
            Manufacturer toAdd = new Manufacturer(1, "name", "email");
            List<Manufacturer> list = new List<Manufacturer>();
            ManufacturerService service = new ManufacturerService(list);

            // Act
            int add = service.AddWithUniqueId(toAdd);

            // Assert
            Assert.Equal(1, add);

            // Checks if it was added and id was changed.
            Manufacturer toCheck = new Manufacturer(-1, "name", "email");
            List<Manufacturer> listToCheck = service.FindDuplicate(toCheck);

            Assert.Single(listToCheck);
        }
    }
}
