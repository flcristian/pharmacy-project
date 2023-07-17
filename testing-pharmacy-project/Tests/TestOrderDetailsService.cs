using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details.service;
using pharmacy_project.order.model;

namespace testing_pharmacy_project.Tests
{
    public class TestOrderDetailsDetailsService 
    {
        [Fact]
        public void FindByOrderId_ValidMatch_ReturnsOrderDetails()
        {
            // Arrange
            int id = 712;
            OrderDetails details = new OrderDetails(1, id, new List<int>{1, 2, 3}, new List<int>{1, 2, 3});
            List<OrderDetails> list = new List<OrderDetails>{details};
            IOrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindByOrderId(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(details.Id, found.Id);
            Assert.Equal(details.OrderId, found.OrderId);
            Assert.Equal(details.MedicineIds, found.MedicineIds);
            Assert.Equal(details.Ammounts, found.Ammounts);
            Assert.Equal(details, found);
        }

        [Fact]
        public void FindByOrderId_MultipleOrderDetails_ReturnsCorrectOrderDetails()
        {
            // Arrange
            int id = 712;
            OrderDetails details = new OrderDetails(1, id, new List<int>{1, 2, 3}, new List<int>{1, 2, 3});
            OrderDetails another = new OrderDetails(2, 91, new List<int>{4, 2, 3}, new List<int>{5, 9, 3});
            List<OrderDetails> list = new List<OrderDetails>{details};
            IOrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindByOrderId(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(details.Id, found.Id);
            Assert.Equal(details.OrderId, found.OrderId);
            Assert.Equal(details.MedicineIds, found.MedicineIds);
            Assert.Equal(details.Ammounts, found.Ammounts);
            Assert.Equal(details, found);
            Assert.NotEqual(another, found);
        }

        [Fact]
        public void FindByOrderId_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 712;
            OrderDetails details = new OrderDetails(1, 2, new List<int>{1, 2, 3}, new List<int>{1, 2, 3});
            List<OrderDetails> list = new List<OrderDetails>{details};
            IOrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindByOrderId(id);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void RemoveByOrderId_NoMatch_DoesNotRemoveOrderDetails_Returns0()
        {
            // Arrange
            int id = 712;
            OrderDetails details = new OrderDetails(1, 2, new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 });
            List<OrderDetails> list = new List<OrderDetails> { details };
            IOrderDetailsService service = new OrderDetailsService(list);

            // Act
            int removed = service.RemoveByOrderId(id);

            // Assert
            Assert.Equal(0, removed);
        }

        [Fact]
        public void RemoveByOrderId_ValidMatch_RemovesOrderDetails_Returns1()
        {
            // Arrange
            int id = 712;
            OrderDetails details = new OrderDetails(1, id, new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 });
            List<OrderDetails> list = new List<OrderDetails> { details };
            IOrderDetailsService service = new OrderDetailsService(list);

            // Act
            int removed = service.RemoveByOrderId(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.Empty(service.GetList());
        }
    }
}