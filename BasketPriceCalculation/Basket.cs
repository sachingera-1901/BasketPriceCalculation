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

        HashSet<Product> usedInOffer;
        HashSet<Offer> offersApplied;

        public Basket()
        {
            products = new List<Product>();
            offers = new List<Offer>();
            usedInOffer = new HashSet<Product>();
            offersApplied = new HashSet<Offer>();
        }

        public Basket(List<Offer> offers)
        {
            products = new List<Product>();
            this.offers = offers;
            usedInOffer = new HashSet<Product>();
            offersApplied = new HashSet<Offer>();
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
            ResetOffersApplied();
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
            ResetOffersApplied();
        }

        public void AddOffer(Offer offer)
        {
            offers.Add(offer);
            ResetOffersApplied();
        }

        public void RemoveOffer(Offer offer)
        {
           offers.Remove(offer);
            ResetOffersApplied();
        }

        public void ResetOffersApplied()
        {
            usedInOffer.Clear();
            offersApplied.Clear();
        }

        public void EmptyBasket()
        {
            products.Clear();
            ResetOffersApplied();
        }

        public void ClearOffers()
        {
            offers.Clear();
            ResetOffersApplied();
        }

        /// <summary>
        /// Everytime this method is called it'll perform calculation
        /// To prevent this we can keep a flag that'll indicate if total has been calculated
        /// and store result in a field variable in this class
        /// then check in this field, return local value if already calculated, otherwise calculate
        /// Reset the bool flag whenever there's change in the basket. Then we also don't need offersApplied HashSet
        ///
        /// For simplicity in this solution I've kept the below code and HashSets will prevent duplicate calculations
        /// </summary>
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
            var discounts = 0M;
            foreach(var offer in offers)
            {
                if (offersApplied.Contains(offer))
                    continue;
                while(offer.ApplyOfferAndCalculateDiscount(Products, usedInOffer, ref discounts))
                {
                    if(!offersApplied.Contains(offer))
                        offersApplied.Add(offer);
                }
                    
            }
            return discounts;
        }
    }
}
