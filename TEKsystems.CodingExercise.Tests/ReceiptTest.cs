using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TEKsystems.CodingExercise.Console.Domain;
using TEKsystems.CodingExercise.Console.Domain.Product;
using TEKsystems.CodingExercise.Console.Utility;
using System.Text.RegularExpressions;

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
            string receiptNormalized = Regex.Replace(receipt, @"\s", "");

            Assert.AreEqual("S.No.ProductNameCountPriceSalesTax------------------------------------1book112.4902musicCD114.991.53chocolatebar10.850-------------------------------------------------------------------TotalSalesTaxes:1.50Total:29.83",
                receiptNormalized);
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
            string receiptNormalized = Regex.Replace(receipt, @"\s", "");

            Assert.AreEqual("S.No.ProductNameCountPriceSalesTax------------------------------------1Importedchocolates110.00.52Importedbottleofperfume147.57.15-------------------------------------------------------------------TotalSalesTaxes:7.65Total:65.15",
                receiptNormalized);
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
            string receiptNormalized = Regex.Replace(receipt, @"\s", "");

            Assert.AreEqual("S.No.ProductNameCountPriceSalesTax------------------------------------1Importedbottleofperfume127.994.22bottleofperfume118.991.93packetofheadachepills19.7504Importedboxofchocolates111.250.6-------------------------------------------------------------------TotalSalesTaxes:6.70Total:74.68",
                receiptNormalized);
        }
    }
}
