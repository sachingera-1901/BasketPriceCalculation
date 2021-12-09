using NUnit.Framework;
using System.Collections.Generic;

namespace BasketPriceCalculation.Tests
{
    public class BasketTests
    {
        List<Offer> offers;
        Basket basket;

        [SetUp]
        public void Setup()
        {
            //Butter - 1, Milk - 2, Bread - 3
            offers = new List<Offer>();
            offers.Add(new Offer(1, 2, 3, 1, 50));
            offers.Add(new Offer(2, 3, 2, 1, 100));
            basket = new Basket(offers);
        }

        [Test]
        public void Giventhebaskethas1butter1milkand1bread_whenItotalthebasket_thenthetotalshouldbe2dot95()
        {
            //Arrange
            basket.AddProduct(new Butter());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Bread());

            //Act and Assert
            Assert.AreEqual(2.95M, basket.Total);
        }

        [Test]
        public void Giventhebaskethas2butterand2bread_whenItotalthebasket_thenthetotalshouldbe3dot10()
        {
            //Arrange
            basket.AddProduct(new Butter());
            basket.AddProduct(new Butter());
            basket.AddProduct(new Bread());
            basket.AddProduct(new Bread());

            //Act and Assert
            Assert.AreEqual(3.10M, basket.Total);
        }

        [Test]
        public void Giventhebaskethas4Milk_whenItotalthebasket_thenthetotalshouldbe3dot45()
        {
            //Arrange
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());

            //Act and Assert
            Assert.AreEqual(3.45M, basket.Total);
        }

        [Test]
        public void Giventhebaskethas2Butter1Breadand8Milk_whenItotalthebasket_thenthetotalshouldbe9()
        {
            //Arrange
            basket.AddProduct(new Butter());
            basket.AddProduct(new Butter());
            basket.AddProduct(new Bread());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Milk());

            //Act and Assert
            Assert.AreEqual(9.0M, basket.Total);
        }

        [TearDown]
        public void TearDown()
        {
            basket.EmptyBasket();
        }
    }
}
