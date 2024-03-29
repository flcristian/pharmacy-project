﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.user.model;
using pharmacy_project.user.service;

namespace testing_pharmacy_project.Tests
{
    public class TestUserService
    {
        [Fact]
        public void FindByEmail_ValidMatch_ReturnsUser_HasCorrectType()
        {
            // Arrange
            string email = "email";
            Customer customer = new Customer(142, "name", email, "password");
            List<User> list = new List<User> { customer };
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmail(email);

            // Assert
            Assert.NotNull(found);
            Assert.Equal("Customer", found.GetType().Name);
            Assert.Equal(customer, found as Customer);
            Assert.Equal(customer.Id, found.Id);
            Assert.Equal(customer.Name, found.Name);
            Assert.Equal(customer.Password, found.Password);
            Assert.Equal(customer.Locked, (found as Customer).Locked);
            Assert.Equal(customer.Email, found.Email);
        }

        [Fact]
        public void FindByEmail_NoMatch_ReturnsNull()
        {
            // Arrange
            string email = "email";
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmail(email);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindByEmail_MultipleUsers_ReturnsCorrectUser_HasCorrectType()
        {
            // Arrange
            string email = "email";
            Customer customer = new Customer(142, "name", email, "password");
            Admin admin = new Admin(95784, "admin", "admin", "admin");
            List<User> list = new List<User> { customer, admin };
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmail(email);

            // Assert
            Assert.NotNull(found);
            Assert.Equal("Customer", found.GetType().Name);
            Assert.Equal(customer, found as Customer);
            Assert.Equal(customer.Id, found.Id);
            Assert.Equal(customer.Name, found.Name);
            Assert.Equal(customer.Password, found.Password);
            Assert.Equal(customer.Locked, (found as Customer).Locked);
            Assert.Equal(customer.Email, found.Email);
        }

        [Fact]
        public void FindByEmailAndPassword_ValidMatch_ReturnsUser_HasCorrectType()
        {
            // Arrange
            string email = "email", password = "password";
            Customer customer = new Customer(142, "name", email, password);
            List<User> list = new List<User> { customer };
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmailAndPassword(email, password);

            // Assert
            Assert.NotNull(found);
            Assert.Equal("Customer", found.GetType().Name);
            Assert.Equal(customer, found as Customer);
            Assert.Equal(customer.Id, found.Id);
            Assert.Equal(customer.Name, found.Name);
            Assert.Equal(customer.Password, found.Password);
            Assert.Equal(customer.Locked, (found as Customer).Locked);
            Assert.Equal(customer.Email, found.Email);
        }

        [Fact]
        public void FindByEmailAndPassword_NoMatch_ReturnsNull()
        {
            // Arrange
            string email = "email", password = "password";
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmailAndPassword(email, password);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindByEmailAndPassword_MultipleUsers_ReturnsCorrectUser_HasCorrectType()
        {
            // Arrange
            string email = "email", password = "password";
            Customer customer = new Customer(142, "name", email, password);
            Admin admin = new Admin(95784, "admin", "admin", "admin");
            List<User> list = new List<User> { customer, admin };
            IUserService service = new UserService(list);

            // Act
            User found = service.FindByEmailAndPassword(email, password);

            // Assert
            Assert.NotNull(found);
            Assert.Equal("Customer", found.GetType().Name);
            Assert.Equal(customer, found as Customer);
            Assert.Equal(customer.Id, found.Id);
            Assert.Equal(customer.Name, found.Name);
            Assert.Equal(customer.Password, found.Password);
            Assert.Equal(customer.Locked, (found as Customer).Locked);
            Assert.Equal(customer.Email, found.Email);
        }

        [Fact]
        public void FindByName_FoundUsers_ReturnsUserList()
        {
            // Arrange
            string name = "name";
            Customer c1 = new Customer(1, name, "email", "password");
            Admin a1 = new Admin(2, name, "email", "password");
            Customer c2 = new Customer(3, name, "email", "password");
            Admin a2 = new Admin(4, name, "email", "password");
            List<User> users = new List<User> { c1, c2, a1, a2 };
            List<User> list = new List<User> { c1, c2, a1, a2 };
            IUserService service = new UserService(list);

            // Act
            List<User> found = service.FindByName(name);

            // Assert
            Assert.NotEmpty(found);
            Assert.Equal(users, found);
            Assert.Equal(4, found.Count());

            int cc = 0, ca = 0;
            foreach(User user in found)
            {
                if(user is Customer)
                {
                    cc++;
                }
                if(user is Admin)
                {
                    ca++;
                }
            }

            Assert.Equal(2, cc);
            Assert.Equal(2, ca);
        }

        [Fact]
        public void FindByName_NoMatch_ReturnsEmptyList()
        {
            // Arrange
            string name = "name";
            List<User> users = new List<User>();
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            List<User> found = service.FindByName(name);

            // Assert
            Assert.Empty(found);
        }

        [Fact]
        public void FindByName_MultipleNamesInList_ReturnsCorrectList()
        {
            // Arrange
            string name = "name";
            Customer c1 = new Customer(1, name, "email", "password");
            Admin a1 = new Admin(2, name, "email", "password");
            Customer c2 = new Customer(3, name, "email", "password");
            Admin a2 = new Admin(4, name, "email", "password");
            Admin a3 = new Admin(5, "george", "emailgeorge", "parolageorge");
            List<User> users = new List<User> { c1, c2, a1, a2 };
            List<User> list = new List<User> { c1, c2, a1, a2, a3 };
            IUserService service = new UserService(list);

            // Act
            List<User> found = service.FindByName(name);

            // Assert
            Assert.NotEmpty(found);
            Assert.Equal(4, found.Count());
            Assert.DoesNotContain(a3, found);

            int cc = 0, ca = 0;
            foreach (User user in found)
            {
                if (user is Customer)
                {
                    cc++;
                }
                if (user is Admin)
                {
                    ca++;
                }
            }

            Assert.Equal(2, cc);
            Assert.Equal(2, ca);
        }

        [Fact]
        public void Add_IdAlreadyUsed_DoesNotAdd_ReturnsNegative1()
        {
            // Arrange
            int id = 18417;
            Customer customer = new Customer(id, "namecustomer", "emailcustomer", "passcustomer");
            List<User> list = new List<User>
            {
                new Customer(id, "name0", "email0","pass0"),
                new Customer(1, "name1","email1","pass1"),
                new Admin(2, "name2","email2","pass2")
            };
            IUserService service = new UserService(list);

            // Act
            int add = service.Add(customer);

            // Assert
            Assert.Equal(-1, add);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void Add_EmailAlreadyUsed_DoesNotAdd_Returns0()
        {
            // Arrange
            string email = "sameemail";
            Customer customer = new Customer(14512, "namecustomer", email, "passcustomer");
            List<User> list = new List<User>
            {
                new Customer(0, "name0", "email0","pass0"),
                new Customer(1, "name1",email,"pass1"),
                new Admin(2, "name2","email2","pass2")
            };
            IUserService service = new UserService(list);

            // Act
            int add = service.Add(customer);

            // Assert
            Assert.Equal(0, add);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void Add_CanAdd_AddsUser_Returns1()
        {
            // Arrange
            Customer customer = new Customer(123, "namecustomer", "emailcustomer", "passcustomer");
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            int add = service.Add(customer);

            // Assert
            Assert.Equal(1, add);
            Assert.Single(list);
        }

        [Fact]
        public void RemoveByEmail_UserNotFound_Returns0()
        {
            // Arrange
            string email = "email31512";
            Customer u1 = new Customer(0, "name0", "email0", "pass0");
            Customer u2 = new Customer(1, "name1", "email1", "pass1");
            Admin u3 = new Admin(2, "name2", "email2", "pass2");
            List<User> list = new List<User> { u1, u2, u3 };
            IUserService service = new UserService(list);

            // Act
            int remove = service.RemoveByEmail(email);

            // Assert
            Assert.Equal(0, remove);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void RemoveByEmail_UserFound_RemovesUser_Returns1()
        {
            // Arrange
            string email = "email1";
            Customer u1 = new Customer(0, "name0", "email0", "pass0");
            Customer u2 = new Customer(1, "name1", "email1", "pass1");
            Admin u3 = new Admin(2, "name2", "email2", "pass2");
            List<User> list = new List<User> { u1, u2, u3 };
            IUserService service = new UserService(list);

            // Act
            int remove = service.RemoveByEmail(email);

            // Assert
            Assert.Equal(1, remove);
            Assert.Equal(2, list.Count());
            Assert.Null(service.FindByEmail(email));
            Assert.DoesNotContain(u2, service.GetList());
        }

        [Fact]
        public void IsAdmin_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            Admin admin = new Admin(1, "name", "emailadmin", "passwordadmin");
            List<User> list = new List<User>{admin};
            IUserService service = new UserService(list);

            // Act
            bool isAdmin = service.IsAdmin(service.FindByEmailAndPassword("emailadmin", "passwordadmin"));

            // Assert
            Assert.True(isAdmin);
        }

        [Fact]
        public void IsAdmin_UserIsNotAdmin_ReturnsFalse()
        {
            // Arrange
            Customer customer = new Customer(1, "name", "email", "password");
            List<User> list = new List<User>{customer};
            IUserService service = new UserService(list);

            // Act
            bool isAdmin = service.IsAdmin(service.FindByEmailAndPassword("email", "password"));

            // Assert
            Assert.False(isAdmin);
        }

        [Fact]
        public void DisplayAdmins_ThereAreAdmins_Returns1()
        {
            // Arrange
            User admin = new Admin(1, "name", "email", "password");
            List<User> list = new List<User>{admin};
            IUserService service = new UserService(list);

            // Act
            int display = service.DisplayAdmins();

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void DisplayAdmin_ThereAreNoAdmins_Returns0()
        {
            // Arrange
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            int display = service.DisplayAdmins();

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void BlockById_UserNotFound_DoesNotBlockCustomer_ReturnsNegative2()
        {
            // Arrange
            int id = 182;
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            int block = service.BlockById(id);

            // Arrange
            Assert.Equal(-2, block);
        }

        [Fact]
        public void BlockById_UserIsNotCustomer_DoesNotBlockCustomer_ReturnsNegative1()
        {
            // Arrange
            int id = 182;
            User user = new User(id, "name", "email", "password", "type");
            List<User> list = new List<User>{user};
            IUserService service = new UserService(list);

            // Act
            int block = service.BlockById(id);

            // Arrange
            Assert.Equal(-1, block);
        }

        [Fact]
        public void BlockById_CustomerIsBlocked_DoesNotBlockCustomer_Returns0()
        {
            // Arrange
            int id = 182;
            Customer customer = new Customer(id, "name", "email", "password");
            customer.Locked = true;
            List<User> list = new List<User>{customer};
            IUserService service = new UserService(list);

            // Act
            int block = service.BlockById(id);

            // Arrange
            Assert.Equal(0, block);
        }

        [Fact]
        public void BlockById_CustomerIsNotBlocked_BlocksCustomer_Returns1()
        {
            // Arrange
            int id = 182;
            Customer customer = new Customer(id, "name", "email", "password");
            List<User> list = new List<User>{customer};
            IUserService service = new UserService(list);

            // Act
            int block = service.BlockById(id);

            // Arrange
            Assert.Equal(1, block);
        }

        [Fact]
        public void UnblockById_UserNotFound_DoesNotBlockCustomer_ReturnsNegative2()
        {
            // Arrange
            int id = 182;
            List<User> list = new List<User>();
            IUserService service = new UserService(list);

            // Act
            int block = service.UnblockById(id);

            // Arrange
            Assert.Equal(-2, block);
        }

        [Fact]
        public void UnblockById_UserIsNotCustomer_DoesNotBlockCustomer_ReturnsNegative1()
        {
            // Arrange
            int id = 182;
            User user = new User(id, "name", "email", "password", "type");
            List<User> list = new List<User>{user};
            IUserService service = new UserService(list);

            // Act
            int block = service.UnblockById(id);

            // Arrange
            Assert.Equal(-1, block);
        }

        [Fact]
        public void UnblockById_CustomerIsNotBlocked_DoesNotBlockCustomer_Returns0()
        {
            // Arrange
            int id = 182;
            Customer customer = new Customer(id, "name", "email", "password");
            List<User> list = new List<User>{customer};
            IUserService service = new UserService(list);

            // Act
            int block = service.UnblockById(id);

            // Arrange
            Assert.Equal(0, block);
        }

        [Fact]
        public void UnblockById_CustomerIsBlocked_BlocksCustomer_Returns1()
        {
            // Arrange
            int id = 182;
            Customer customer = new Customer(id, "name", "email", "password");
            customer.Locked = true;
            List<User> list = new List<User>{customer};
            IUserService service = new UserService(list);

            // Act
            int block = service.UnblockById(id);

            // Arrange
            Assert.Equal(1, block);
        }
    }
}
