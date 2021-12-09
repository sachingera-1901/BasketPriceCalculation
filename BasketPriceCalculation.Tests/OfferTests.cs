using NUnit.Framework;
using System.Collections.Generic;

namespace BasketPriceCalculation.Tests
{
    public class OfferTests
    {

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Giventhebaskethas1butter1milkand1bread_whenItotalthebasket_thenthediscountshouldbe0()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Butter());
            products.Add(new Milk());
            products.Add(new Bread());

            var usedInOffer = new HashSet<Product>();
            var offer = new Offer(1, 2, 3, 1, 50);
            var discount = 0M;

            //Act
            var result = offer.ApplyOfferAndCalculateDiscount(products, usedInOffer, ref discount);


            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(0.0M, discount);
        }

        [Test]
        public void Giventhebaskethas2butterand2bread_whenItotalthebasket_thenthediscountshouldbe0dot5()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Butter());
            products.Add(new Butter());
            products.Add(new Bread());
            products.Add(new Bread());

            var usedInOffer = new HashSet<Product>();
            var offer = new Offer(1, 2, 3, 1, 50);
            var discount = 0M;

            //Act
            var result = offer.ApplyOfferAndCalculateDiscount(products, usedInOffer, ref discount);


            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0.5M, discount);
        }

        [Test]
        public void Giventhebaskethas4Milk_whenItotalthebasket_thenthediscountshouldbe1dot15()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Milk());
            products.Add(new Milk());
            products.Add(new Milk());
            products.Add(new Milk());

            var usedInOffer = new HashSet<Product>();
            var offer = new Offer(2, 3, 2, 1, 100);
            var discount = 0M;

            //Act
            var result = offer.ApplyOfferAndCalculateDiscount(products, usedInOffer, ref discount);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1.15M, discount);
        }
    }
}