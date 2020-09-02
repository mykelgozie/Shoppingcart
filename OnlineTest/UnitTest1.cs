using NUnit.Framework;
using Onlinestore.Lib;
using System.Diagnostics;

namespace OnlineTest
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void AddToCart()
        {
            ProcessproductClass product = new ProcessproductClass();
            // arrange
            var id = 39;
            var name = "orange";
            var price = 12292.00M;
            var quantity = 7;
            var date = "2000 - 03 - 03";
            var expected = ChartClass.shoppingChart.Count + 1;
            //act
            product.AddToChart(id, name, price, quantity, date);
            // count cart
            var actualcount = ChartClass.shoppingChart.Count;

            // assert 
            Assert.That(actualcount, Is.EqualTo(expected));
        }

        [Test]
        public void DeleteCartTest()
        {

            ProcessproductClass product = new ProcessproductClass();
            // arrange
            var id = 39;
            var name = "orange";
            var price = 12292.00M;
            var quantity = 7;
            var date = "2000 - 03 - 03";
            // add product to cart
            product.AddToChart(id, name, price, quantity, date);
            // count cart
            var count = ChartClass.shoppingChart.Count;
            // expected result
            var expected = ChartClass.shoppingChart.Count - 1;

            // Act
            product.DeleteProductFromChart(id.ToString());
            var result = ChartClass.shoppingChart.Count;
            //Assert
            Assert.That(result, Is.EqualTo(expected));




        }
    }
}