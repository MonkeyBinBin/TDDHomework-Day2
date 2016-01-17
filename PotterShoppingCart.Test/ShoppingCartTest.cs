using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PotterShoppingCart;

namespace PotterShoppingCart.Test
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void Test_第一集買一本其他都沒買_價格應為100元()
        {
            //arrange
            var target = new ShoppingCart();
            var products = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="哈利波特第一集",Price=100}
            };
            target.AddProducts(products);

            var expected = 100;

            //act
            var actual = target.GetTotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
