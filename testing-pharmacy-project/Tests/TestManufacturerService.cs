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
        public void FindByEmail_ValidMatch_ReturnsManufacturer()
        {
            // Arrange
            string email = "thisemail@gog.com";
            Manufacturer expected = new Manufacturer(1, "name", email);
            List<Manufacturer> list = new List<Manufacturer> { expected };
            IManufacturerService service = new ManufacturerService(list);

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
            IManufacturerService service = new ManufacturerService(list);

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
            IManufacturerService service = new ManufacturerService(list);

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
            IManufacturerService service = new ManufacturerService(list);

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
            IManufacturerService service = new ManufacturerService(list);

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
            IManufacturerService service = new ManufacturerService(list);

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
    }
}
