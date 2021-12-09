using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BasketPriceCalculation
{
    public class Offer
    {
        int offerProductId;
        int offerProductQuantity;
        int discountedProductId;
        int discountedProductQuantity;
        decimal discountPercentage;

        public Offer(   int offerProductId,
                        int offerProductQuantity,
                        int discountedProductId,
                        int discountedProductQuantity,
                        decimal discountPercentage){
            this.offerProductId = offerProductId;
            this.offerProductQuantity = offerProductQuantity;
            this.discountedProductId = discountedProductId;
            this.discountedProductQuantity = discountedProductQuantity;
            this.discountPercentage = discountPercentage;
        }

        public bool ApplyOfferAndCalculateDiscount(List<Product> products, HashSet<Product> usedInOffer, ref decimal discount)
        {
            var tempSet = new HashSet<Product>();

            //get list of avaialble products
            var availProducts = products.Where(x => !usedInOffer.Contains(x)).ToList();

            //check offer products are there in the list and available
            var offerProductsAvailable = 0;
            for (int i = 0; i < availProducts.Count; i++)
            {
                if (offerProductsAvailable == offerProductQuantity)
                    break;

                if (availProducts[i].Id != offerProductId)
                    continue;

                tempSet.Add(availProducts[i]);
                offerProductsAvailable++;
            }

            if (offerProductsAvailable < offerProductQuantity)
                return false;

            //check discounted products and calculate discount
            var discountedProductsAvailable = 0;
            for (int i = 0; i < availProducts.Count; i++)
            {
                if (discountedProductsAvailable == discountedProductQuantity)
                    break;

                if (tempSet.Contains(availProducts[i]) || availProducts[i].Id != discountedProductId)
                    continue;

                tempSet.Add(availProducts[i]);
                discountedProductsAvailable++;
                discount += availProducts[i].UnitPrice * (discountPercentage / 100); 
            }

            if (discountedProductsAvailable > 0)
                foreach(var product in tempSet)
                {
                    usedInOffer.Add(product);
                }
            return discountedProductsAvailable > 0;
        }

    }
}
