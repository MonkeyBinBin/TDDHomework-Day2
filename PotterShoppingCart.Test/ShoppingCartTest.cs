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

        [TestMethod]
        public void Test_第一集買一本_第二集也買一本_價格應為190()
        {
            //arrange
            var target = new ShoppingCart();
            var products = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="哈利波特第一集",Price=100},
                new Product{ ProductId=2,ProductName="哈利波特第二集",Price=100}
            };
            target.AddProducts(products);

            var expected = 190;

            //act
            var actual = target.GetTotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三集各買了一本_價格應為270()
        {
            //arrange
            var target = new ShoppingCart();
            var products = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="哈利波特第一集",Price=100},
                new Product{ ProductId=2,ProductName="哈利波特第二集",Price=100},
                new Product{ ProductId=3,ProductName="哈利波特第三集",Price=100}
            };
            target.AddProducts(products);

            var expected = 270;

            //act
            var actual = target.GetTotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為320()
        {
            //arrange
            var target = new ShoppingCart();
            var products = new List<Product>()
            {
                new Product{ ProductId=1,ProductName="哈利波特第一集",Price=100},
                new Product{ ProductId=2,ProductName="哈利波特第二集",Price=100},
                new Product{ ProductId=3,ProductName="哈利波特第三集",Price=100},
                new Product{ ProductId=4,ProductName="哈利波特第四集",Price=100}
            };
            target.AddProducts(products);

            var expected = 320;

            //act
            var actual = target.GetTotalPrice();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
