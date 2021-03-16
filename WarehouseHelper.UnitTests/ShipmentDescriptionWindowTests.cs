using NUnit.Framework;
using System;
using System.Windows;

namespace WarehouseHelper.UnitTests
{
    [TestFixture]
    public class ShipmentDescriptionWindowTests
    {
        [Test]
        public void IsValid_NullableProduct_ReturnsFalse()
        {
            Product product = null;

            bool isValid = ShipmentDescriptionWindow.IsValid(product, "123");

            Assert.False(isValid);
        }


        [Test]
        public void IsValid_NotParsableTxtCount_ReturnsFalse()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Name",
                Count = 2, MaxCount = 10,
            };

            bool isValid = ShipmentDescriptionWindow.IsValid(product, "not parsable string");

            Assert.False(isValid);
        }


        [Test]
        public void IsValid_NotPositiveCount_ReturnsFalse()
        {
            Product product = new Product();

            bool isValid = ShipmentDescriptionWindow.IsValid(product, "-1");
            isValid |= ShipmentDescriptionWindow.IsValid(product, "0");

            Assert.False(isValid);
        }


        [TestCase(4, 10, 1, ExpectedResult = true)]
        [TestCase(4, 10, 2, ExpectedResult = true)]
        [TestCase(4, 10, 3, ExpectedResult = true)]
        [TestCase(4, 10, 4, ExpectedResult = true)]
        [TestCase(4, 10, 5, ExpectedResult = false)]
        [TestCase(4, 10, 6, ExpectedResult = false)]
        [TestCase(4, 10, 10, ExpectedResult = false)]
        public bool IsValid_CanShipMore(int currentCount, int capacity, int count)
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Name",
                Count = currentCount,
                MaxCount = capacity,
            };

            return ShipmentDescriptionWindow.IsValid(product, count.ToString());
        }
    }
}
