using pharmacy_project.order_details.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_pharmacy_project.Tests
{
    public class TestOrderDetails
    {
        [Fact]
        public void IndexOfMedicine_ValidMatch_ReturnsIndex()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10 });

            // Act
            int found = details.IndexOfMedicine(id);

            // Assert
            Assert.Equal(0, found);
        }

        [Fact]
        public void IndexOfMedicine_NoMatch_ReturnsNegative1()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> {};
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> {});

            // Act
            int found = details.IndexOfMedicine(id);

            // Assert
            Assert.Equal(-1, found);
        }

        [Fact]
        public void IndexOfMedicine_MultipleIds_ReturnsCorrectIndex()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { 1, id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10, 20 });

            // Act
            int found = details.IndexOfMedicine(id);

            // Assert
            Assert.Equal(1, found);
        }

        [Fact]
        public void RemoveMedicineId_ValidMatch_RemovesIdAndAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10 });

            // Act
            int removed = details.RemoveMedicineId(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.Empty(details.MedicineIds);
            Assert.Empty(details.Ammounts);
        }

        [Fact]
        public void RemoveMedicineId_NoMatch_DoesNotRemoveIdAndAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { 92 };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10 });

            // Act
            int removed = details.RemoveMedicineId(id);

            // Assert
            Assert.Equal(0, removed);
            Assert.NotEmpty(details.MedicineIds);
            Assert.NotEmpty(details.Ammounts);
        }

        [Fact]
        public void RemoveMedicineId_MultipleIds_RemovesCorrectIdAndAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { 92, id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10, 20 });

            // Act
            int removed = details.RemoveMedicineId(id);

            // Assert
            Assert.Equal(1, removed);
            Assert.NotEmpty(details.MedicineIds);
            Assert.NotEmpty(details.Ammounts);
            Assert.DoesNotContain(id, details.MedicineIds);
            Assert.DoesNotContain(20, details.Ammounts);
        }

        [Fact]
        public void EditAmmountByMedicineId_ValidMatch_EditsAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10 });

            // Act
            int edited = details.EditAmmountByMedicineId(id, 20);

            // Assert
            Assert.Equal(1, edited);
            Assert.DoesNotContain(10, details.Ammounts);
            Assert.Contains(20, details.Ammounts);
        }

        [Fact]
        public void EditAmmountByMedicineId_NoMatch_DoesNotAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { 30 };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 10 });

            // Act
            int edited = details.EditAmmountByMedicineId(id, 20);

            // Assert
            Assert.Equal(0, edited);
            Assert.Contains(10, details.Ammounts);
        }

        [Fact]
        public void EditAmmountByMedicineId_MultipleIds_EditsCorrectAmmount()
        {
            // Arrange
            int id = 100;
            List<int> list = new List<int> { 1, id };
            OrderDetails details = new OrderDetails(1, 1, list, new List<int> { 5, 10 });

            // Act
            int edited = details.EditAmmountByMedicineId(id, 20);

            // Assert
            Assert.Equal(1, edited);
            Assert.Equal(5, details.Ammounts[0]);
            Assert.Contains(20, details.Ammounts);
        }
    }
}
