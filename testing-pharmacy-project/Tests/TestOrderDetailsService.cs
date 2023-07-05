using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pharmacy_project.order_details.model;
using pharmacy_project.order_details.service;

namespace testing_pharmacy_project.Tests
{
    public class TestOrderDetailsDetailsService {
        [Fact]
        public void FindById_ValidMatch_ReturnsOrderDetails()
        {
            // Arrange
            int id = 1674;
            OrderDetails orderDetails = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {5, 20});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(1, found.OrderId);
            Assert.Equal(new List<int> {1, 2}, found.MedicineIds);
            Assert.Equal(new List<int> {5, 20}, found.Ammounts);
            Assert.Equal(orderDetails, found);
        }

        [Fact]
        public void FindById_NoMatch_ReturnsNull()
        {
            // Arrange
            int id = 1674;
            List<OrderDetails> list = new List<OrderDetails>();
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindById(id);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void FindById_MultipleOrderDetails_ReturnsCorrectOrderDetails()
        {
            // Arrange
            int id = 1674;
            OrderDetails orderDetails = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {5, 20});
            OrderDetails another = new OrderDetails(910, 2, new List<int>{2,3}, new List<int> {5, 20});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails, another };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            OrderDetails found = service.FindById(id);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(id, found.Id);
            Assert.Equal(1, found.OrderId);
            Assert.Equal(new List<int> {1, 2}, found.MedicineIds);
            Assert.Equal(new List<int> {5, 20}, found.Ammounts);
            Assert.Equal(orderDetails, found);
            Assert.NotEqual(another, found);
        }

        [Fact]
        public void ClearList_EmptiesList()
        {
            // Arrange
            List<OrderDetails> list = new List<OrderDetails>
            {
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),                
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10})
            };
            OrderDetailsService service = new OrderDetailsService(list);

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
            List<OrderDetails> list = new List<OrderDetails>
            {
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),                
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10})
            };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int count = service.Count();

            // Assert
            Assert.Equal(4, count);
        }

        [Fact]
        public void NewId_ReturnsUnusedId_ReturnsIdInRange()
        {
            // Arrange
            List<OrderDetails> list = new List<OrderDetails>
            {
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),                
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}),
                new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10})
            };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int newId = service.NewId();

            // Assert
            Assert.InRange(newId, 1, 999999);
            foreach (OrderDetails orderDetails in service.GetList())
            {
                Assert.NotEqual(newId, orderDetails.Id);
            }
        }

        [Fact]
        public void Add_IdAlreadyUsed_DoesNotAdd_Returns0()
        {
            // Arrange
            int id = 1674;
            OrderDetails toAdd = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
            OrderDetails orderDetails = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
                
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(0, add);
            Assert.Equal(1, service.Count());
            Assert.DoesNotContain(toAdd, service.GetList());
        }

        [Fact]
        public void Add_IdNotUsed_AddsOrderDetails_Returns1()
        {
            // Arrange
            int id = 1674;
            OrderDetails toAdd = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
            OrderDetails orderDetails = new OrderDetails(902, 1, new List<int>{1,2}, new List<int> {0, 10});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int add = service.Add(toAdd);

            // Assert
            Assert.Equal(1, add);
            Assert.Equal(2, service.Count());
            Assert.Contains(toAdd, service.GetList());
        }

        [Fact]
        public void RemoveById_OrderDetailsNotFound_DoesNotRemoveOrderDetails_Returns0()
        {
            // Arrange
            int id = 1674;
            OrderDetails orderDetails = new OrderDetails(902, 1, new List<int>{1,2}, new List<int> {0, 10});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(0, remove);
            Assert.Equal(1, service.Count());
            Assert.Contains(orderDetails, service.GetList());
        }

        [Fact]
        public void RemoveById_OrderDetailsFound_RemovesOrderDetails_Returns1()
        {
            // Arrange
            int id = 1674;
            OrderDetails orderDetails = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

            // Act
            int remove = service.RemoveById(id);

            // Assert
            Assert.Equal(1, remove);
            Assert.Empty(service.GetList());
            Assert.Equal(0, service.Count());
            Assert.DoesNotContain(orderDetails, service.GetList());
        }

        [Fact]
        public void EditById_OrderDetailsFound_EditsOrderDetails_Returns1()
        {
            // Arrange
            int id = 1674;
            OrderDetails edited = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
            OrderDetails orderDetails = new OrderDetails(id, 1, new List<int>{1,2}, new List<int> {0, 10});
            List<OrderDetails> list = new List<OrderDetails> { orderDetails };
            OrderDetailsService service = new OrderDetailsService(list);

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
            List<OrderDetails> list = new List<OrderDetails> { new OrderDetails(1, 1, new List<int>{1,2}, new List<int> {0, 10}) };
            OrderDetailsService service = new OrderDetailsService(list);
            
            // Act
            List<OrderDetails> returned = service.GetList();
            
            // Assert
            Assert.Equal(list, returned);
        }
    }
}