using pharmacy_project.order.model;
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
        public void DisplayByStatus_OrderNotFound_Returns0()
        {
            // Arrange
            string status = "Completed";
            Order order = new Order(182, 1, "Submitted");
            List<Order> list = new List<Order> { order };
            IOrderService service = new OrderService(list);

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
            IOrderService service = new OrderService(list);

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
            IOrderService service = new OrderService(list);

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
            IOrderService service = new OrderService(list);

            // Act
            int display = service.DisplayByStatusSortedByDate(status);

            // Assert
            Assert.Equal(1, display);
        }

        [Fact]
        public void FindByCustomerId_ReturnsCorrectList()
        {
            // Arrange
            int id = 1;
            Order o1 = new Order(1, id, "status");
            Order o2 = new Order(2, 3, "status");
            Order o3 = new Order(3, id, "status");
            List<Order> list = new List<Order> { o1, o2, o3 };
            IOrderService service = new OrderService(list);

            // Act
            List<Order> found = service.FindByCustomerId(id);

            // Assert
            Assert.Contains(o1, found);
            Assert.DoesNotContain(o2, found);
            Assert.Contains(o3, found);
        }
    }
}
