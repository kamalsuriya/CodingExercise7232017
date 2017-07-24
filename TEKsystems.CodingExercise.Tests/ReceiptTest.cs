using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TEKsystems.CodingExercise.Console.Domain;
using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Utility;

namespace TEKsystems.CodingExercise.Tests
{
    [TestClass]
    public class ReceiptTest
    {
        [TestMethod]
        public void ShouldCreateReceiptForBasket1()
        {
            var book = new Book { Id = 1, Name = "book", Price = 12.49m };
            var musicCd = new Music { Id = 2, Name = "music CD", Price = 14.99m };
            var chocolateBar = new Food { Id = 3, Name = "chocolate bar", Price = 0.85m };

            var cart = new Cart { Id = 1 };
            cart.Products.Add( book );
            cart.Products.Add( musicCd );
            cart.Products.Add( chocolateBar );

            var receipt = Receipt.Instance.Create( cart );

            Assert.AreEqual("S.No.  Product Name   Count  Price  Sales Tax  \n-----  ------------   -----  -----  ---------\n1      book           1      12.49  0\n2      music CD       1      14.99  1.5\n3      chocolate bar  1      0.85   0\nTotal Sales Taxes: 1.50\nTotal: 29.83",
                receipt);
        }
        
        [TestMethod]
        public void ShouldCreateReceiptForBasket2()
        {
            var chocolates = new Food { Id = 4, Name = "chocolates", Price = 10.0m, IsImported = true };
            var perfume = new Perfume { Id = 5, Name = "bottle of perfume", Price = 47.5m, IsImported = true };

            var cart = new Cart { Id = 2 };
            cart.Products.Add( chocolates );
            cart.Products.Add( perfume );

            var receipt = Receipt.Instance.Create( cart );

            Assert.AreEqual("S.No.  Product Name                 Count  Price  Sales Tax  \n-----  ------------                 -----  -----  ---------  \n1      Imported  chocolates         1      10.0   0.5\n2      Imported  bottle of perfume  1      47.5   7.15\nTotal Sales Taxes: 7.65\nTotal: 65.15",
                receipt );
        }
        
        [TestMethod]
        public void ShouldCreateReceiptForBasket3()
        {
            var importedPerfume = new Perfume { Id = 6, Name = "bottle of perfume", Price = 27.99m, IsImported = true };
            var perfume = new Perfume { Id = 7, Name = "bottle of perfume", Price = 18.99m };
            var pills = new Medical { Id = 8, Name = "packet of headache pills", Price = 9.75m };
            var chocolates = new Food { Id = 9, Name = "box of chocolates", Price = 11.25m, IsImported = true };

            var cart = new Cart { Id = 3 };
            cart.Products.Add( importedPerfume );
            cart.Products.Add( perfume );
            cart.Products.Add( pills );
            cart.Products.Add( chocolates );

            var receipt = Receipt.Instance.Create( cart );

            Assert.AreEqual("S.No.  Product Name                 Count  Price  Sales Tax  \n-----  ------------                 -----  -----  ---------  \n1      Imported  bottle of perfume  1      27.99  4.2\n2      bottle of perfume            1      18.99  1.9\n3      packet of headache pills     1      9.75   0\n4      Imported  box of chocolates  1      11.25  0.6\nTotal Sales Taxes: 6.70\nTotal: 74.68", 
                receipt );
        }
    }
}
