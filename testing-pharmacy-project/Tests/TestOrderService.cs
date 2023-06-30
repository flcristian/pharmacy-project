﻿using pharmacy_project.order.model;
using pharmacy_project.order.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_pharmacy_project.Tests
{
    public class TestOrderService
    {
        [Fact]
        public void FindById_ValidMatch_ReturnsOrder()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(id, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            Order found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(1, found.CustomerId);
            Assert.Equal("Submitted", found.Status);
            Assert.Equal(order, found);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 1674;
            List<Order> list = new List<Order>();
            OrderService service = new OrderService(list);

            // Act
            Order found = service.FindById(id);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindById_MultipleOrder_ReturnsCorrectOrder()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(id, 1, "Submitted");
            Order another = new Order(71, 1, "anotherSubmitted");
            List<Order> list = new List<Order> { order, another };
            OrderService service = new OrderService(list);

            // Act
            Order found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(1, found.CustomerId);
            Assert.Equal("Submitted", found.Status);
            Assert.Equal(order, found);
            Assert.NotEqual(another, found);
        }

        [Fact]
        public void DisplayById_OrderNotFound_Returns0()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(182, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayById_OrderFound_Returns1()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(id, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayById(id);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void DisplayByIdCustomer_OrderNotFound_Returns0()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(182, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByIdCustomer(id);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayByIdCustomer_OrderFound_Returns1()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(id, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByIdCustomer(id);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void DisplayByStatus_OrderNotFound_Returns0()
        {
            // Arrange
            string status = "Completed";
            Order order = new Order(182, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByStatus(status);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayByStatus_OrderFound_Returns1()
        {
            // Arrange
            string status = "Completed";
            Order order = new Order(182, 1, status);
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByStatus(status);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void DisplayByStatusSortedByDate_OrderNotFound_Returns0()
        {
            // Arrange
            string status = "Submitted";
            Order order = new Order(182, 1, "status");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByStatusSortedByDate(status);

            // Assert
            Assert.Equal(0, display);
        }

        [Fact]
        public void DisplayByStatusSortedByDate_OrderFound_Returns1()
        {
            // Arrange
            string status = "Submitted";
            Order order = new Order(182, 1, status);
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByStatusSortedByDate(status);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void ClearList_EmptiesList()
        {
            // Arrange
            List<Order> list = new List<Order>
            {
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted")
            };
            OrderService service = new OrderService(list);

            // Act
            service.ClearList();

            // Assert
            Assert.Empty(service.GetList());
            Assert.Equal(0, service.Count());
        }

        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            // Arrange
            List<Order> list = new List<Order>
            {
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted"),
                new Order(1,1,"Submitted")
            };
            OrderService service = new OrderService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(4, count);
        }

        [Fact]
        public void NewId_ReturnsUnusedId_ReturnsIdInRange()
        {
            // Arrange
            List<Order> list = new List<Order>
            {
                new Order(1,1,"Submitted"),
                new Order(2,1,"Submitted"),
                new Order(3,1,"Submitted"),
                new Order(4,1,"Submitted")
            };
            OrderService service = new OrderService(list);

            // Act
            int newId = service.NewId();

            // Assert
            Assert.InRange(newId, 1, 999999);
            foreach (Order order in service.GetList())
            {
                Assert.NotEqual(newId, order.Id);
            }
        }

        [Fact]
        public void Add_IdAlreadyUsed_DoesNotAdd_Returns0()
        {
            // Arrange
            int id = 1674;
            Order toAdd = new Order(id, 1, "Submitted");
            Order order = new Order(id, 2, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.Equal(1, service.Count());
            Assert.DoesNotContain(toAdd, service.GetList());
        }

        [Fact]
        public void Add_IdNotUsed_AddsOrder_Returns1()
        {
            // Arrange
            int id = 1674;
            Order toAdd = new Order(id, 1, "Submitted");
            Order order = new Order(182, 2, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(1, add);
            Assert.Equal(2, service.Count());
            Assert.Contains(toAdd, service.GetList());
        }

        [Fact]
        public void RemoveById_OrderNotFound_DoesNotRemoveOrder_Returns0()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(52, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(0, remove);
            Assert.Equal(1, service.Count());
            Assert.Contains(order, service.GetList());
        }

        [Fact]
        public void RemoveById_OrderFound_RemovesOrder_Returns1()
        {
            // Arrange
            int id = 1674;
            Order order = new Order(id, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(1, remove);
            Assert.Empty(service.GetList());
            Assert.Equal(0, service.Count());
            Assert.DoesNotContain(order, service.GetList());
        }

        [Fact]
        public void EditById_OrderNotFound_DoesNotEditOrder_Returns0()
        {
            // Arrange
            int id = 1674;
            Order edited = new Order(id, 0, "Submitted");
            Order order = new Order(189, 0, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int edit = service.EditById(edited, id);

            // Assert
            Assert.Equal(0, edit);
            Assert.DoesNotContain(edited, service.GetList());
            Assert.NotEqual(service.FindById(189), edited);
        }

        [Fact]
        public void EditById_OrderFound_EditsOrder_Returns1()
        {
            // Assert
            int id = 1674;
            Order edited = new Order(id, 0, "Submitted");
            Order order = new Order(id, 0, "Submitted");
            List<Order> list = new List<Order> { order };
            OrderService service = new OrderService(list);

            // Act
            int edit = service.EditById(edited, id);

            // Assert
            Assert.Equal(1, edit);
            Assert.Contains(edited, service.GetList());
            Assert.Equal(service.FindById(id), edited);
        }

        [Fact]
        public void GetList_ReturnsSameList()
        {
            // Arrange
            List<Order> list = new List<Order> { new Order(1,1,"status") };
            OrderService service = new OrderService(list);

            // Act
            List<Order> returned = service.GetList();

            // Assert
            Assert.Equal(list, returned);
        }
    }
}
