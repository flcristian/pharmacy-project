using System;
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
        public void FindById_ValidMatch_ReturnsUser_HasCorrectType()
        {
            // Arrange
            int id = 142;
            Customer customer = new Customer(id, "name", "email", "password");
            List<User> list = new List<User> { customer };
            UserService service = new UserService(list);

            // Act
            User found = service.FindById(id);

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
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 142;
            List<User> list = new List<User>();
            UserService service = new UserService(list);

            // Act
            User found = service.FindById(id);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindById_MultipleUsers_ReturnsCorrectUser_HasCorrectType()
        {
            // Arrange
            int id = 142;
            Customer customer = new Customer(id, "name", "email", "password");
            Admin admin = new Admin(95784, "admin", "admin", "admin");
            List<User> list = new List<User> { customer, admin };
            UserService service = new UserService(list);

            // Act
            User found = service.FindById(id);

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
        public void FindByEmail_ValidMatch_ReturnsUser_HasCorrectType()
        {
            // Arrange
            string email = "email";
            Customer customer = new Customer(142, "name", email, "password");
            List<User> list = new List<User> { customer };
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
            UserService service = new UserService(list);

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
        public void Count_ReturnsCorrectCount()
        {
            // Arrange
            List<User> list = new List<User>
            {
                new User(1,"name","email","password","type"),
                new User(2,"name","email","password","type")
            };
            UserService service = new UserService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(list.Count(), count);
        }

        [Fact]
        public void ClearList_ListIsEmptyAfterFunctionCall()
        {
            // Arrange
            List<User> list = new List<User>
            {
                new User(1,"name","email","password","type"),
                new User(2,"name","email","password","type")
            };
            UserService service = new UserService(list);

            // Act
            service.ClearList();

            // Assert
            Assert.Empty(service.List);
        }

        [Fact]
        public void NewId_ReturnsUnusedId_ReturnsIdInRange()
        {
            // Arrange
            User u1 = new User(112341, "name", "email@email.com", "pass", "Admin");
            User u2 = new User(281723, "name", "email@email.com", "pass", "Admin");
            User u3 = new User(911913, "name", "email@email.com", "pass", "Admin");
            User u4 = new User(333224, "test", "test", "pass", "Admin");
            User u5 = new User(576765, "another", "another", "pass", "Admin");
            List<User> list = new List<User> { u1, u2, u3, u4, u5 };
            UserService service = new UserService(list);

            // Act
            int id = service.NewId();

            // Assert
            foreach (User u in list)
            {
                Assert.NotEqual(u.Id, id);
            }
            Assert.InRange(id, 1, 999999);
        }

        [Fact]
        public void AddUser_IdAlreadyUsed_DoesNotAddUser_ReturnsNegative1()
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
            UserService service = new UserService(list);

            // Act
            int add = service.AddUser(customer);

            // Assert
            Assert.Equal(-1, add);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void AddUser_EmailAlreadyUsed_DoesNotAddUser_Returns0()
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
            UserService service = new UserService(list);

            // Act
            int add = service.AddUser(customer);

            // Assert
            Assert.Equal(0, add);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void AddUser_CanAdd_AddsUser_Returns1()
        {
            // Arrange
            Customer customer = new Customer(123, "namecustomer", "emailcustomer", "passcustomer");
            List<User> list = new List<User>();
            UserService service = new UserService(list);

            // Act
            int add = service.AddUser(customer);

            // Assert
            Assert.Equal(1, add);
            Assert.Equal(1, list.Count());
        }
    }
}
