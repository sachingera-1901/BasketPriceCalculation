using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasketPriceCalculation
{
    public class Basket
    {
        List<Product> products;
        List<Offer> offers;

        public Basket()
        {
            products = new List<Product>();
            offers = new List<Offer>();
        }

        public Basket(List<Offer> offers)
        {
            products = new List<Product>();
            this.offers = offers;
        }

        public List<Product> Products{
            get 
            {
                return products;
            }
        }

        public List<Offer> Offers
        {
            get
            {
                return offers;
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public void AddOffer(Offer offer)
        {
            offers.Add(offer);
        }

        public void RemoveOffer(Offer offer)
        {
           offers.Remove(offer);
        }

        public void EmptyBasket()
        {
            products.Clear();
        }

        public void ClearOffers()
        {
            offers.Clear();
        }

        public decimal Total
        {
            get
            {
                var sum = products.Sum(x => x.UnitPrice);
                return sum - GetDiscounts();
            }
        }

        private decimal GetDiscounts()
        {
            var usedInOffer = new HashSet<Product>();
            var discounts = 0M;
            foreach(var offer in offers)
            {
                //Apply offer again if successful
                while(offer.ApplyOfferAndCalculateDiscount(Products, usedInOffer, ref discounts))
                {
                    
                }
                    
            }
            return discounts;
        }
    }
}
