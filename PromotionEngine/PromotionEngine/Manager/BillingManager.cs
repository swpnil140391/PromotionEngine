using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Manager
{
    /// <summary>
    /// Billing Manager will finally will be responsible for Getting Itemzied & Final Amount
    /// </summary>
    class BillingManager
    {
        public void PerformOperation(int code)
        {
            if(OperationManager._PurchaseManager.CurrentOrderDetails.Count == 0)
            {
                Console.WriteLine("No Purchase Orders Found");
                return;
            }
            int finalamount = 0;
            foreach (var item in OperationManager._PurchaseManager.CurrentOrderDetails)
            {
                PromotionDetails promOffer = OperationManager._PromotionManager.GetPromotionOffer(item.SKUID);
                if (promOffer == null)
                {
                    int price = GetPrice(item.SKUID, item.Quantity);
                    finalamount = finalamount + price;
                    Console.WriteLine("Price for SKUID : " + item.SKUID + " Quantity " + item.Quantity + " Is " + price);
                }
            }
            foreach (var item in OperationManager._PurchaseManager.CurrentOrderDetails)
            {
                PromotionDetails promOffer = OperationManager._PromotionManager.GetPromotionOffer(item.SKUID);
                if (promOffer != null)
                {
                    switch (promOffer.Type)
                    {
                        case PromotionType.Count:
                            if(item.Quantity < promOffer.Count)
                            {
                                int price = GetPrice(item.SKUID, item.Quantity);
                                finalamount = finalamount + price;
                                Console.WriteLine("Price for SKUID : " + item.SKUID + " Quantity " + item.Quantity + " Is " + price);
                            }
                            else
                            {
                                int price = GetDiscountedPrice(item.SKUID, item.Quantity, promOffer);
                                finalamount = finalamount + price;
                                Console.WriteLine("Price for SKUID : " + item.SKUID + " Quantity " + item.Quantity + " Is " + price);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            List<string> prompocodeapplied = new List<string>();
            for (int i = OperationManager._PurchaseManager.CurrentOrderDetails.Count - 1; i >= 0; i--)
            {
                PromotionDetails promOffer = OperationManager._PromotionManager.GetPromotionOffer(OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID);
                if (promOffer != null)
                {
                    switch (promOffer.Type)
                    {
                        case PromotionType.Combined:
                            if (!ContainesBothSKUIDs(OperationManager._PurchaseManager.CurrentOrderDetails, promOffer.SKUIDs) && !prompocodeapplied.Contains(OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID))
                            {
                                finalamount = finalamount + (OperationManager._SKUDetailsManager.SKUDetails[OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID] * OperationManager._PurchaseManager.CurrentOrderDetails[i].Quantity);
                                Console.WriteLine("Price for SKUID : " + OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID + " Quantity " + OperationManager._PurchaseManager.CurrentOrderDetails[i].Quantity + " Is " + (OperationManager._SKUDetailsManager.SKUDetails[OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID] * OperationManager._PurchaseManager.CurrentOrderDetails[i].Quantity));
                            }
                            else if (!prompocodeapplied.Contains(OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID))
                            {
                                finalamount = finalamount + promOffer.DiscountPrice;
                                Console.WriteLine("Price for SKUID : " + OperationManager._PurchaseManager.CurrentOrderDetails[i].SKUID + " Quantity " + OperationManager._PurchaseManager.CurrentOrderDetails[i].Quantity + " Is " + promOffer.DiscountPrice);
                                OperationManager._PurchaseManager.CurrentOrderDetails.RemoveAt(i);
                                prompocodeapplied.AddRange(promOffer.SKUIDs);
                            }
                            else
                            {

                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("Final Bill : " + finalamount);
        }

        /// <summary>
        /// Check if Combinaed both SKUS offer is valid on order or not
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="skuids"></param>
        /// <returns></returns>
        private bool ContainesBothSKUIDs(List<OrderDetails> orders, List<string> skuids)
        {
            int exists = 0;
            foreach (var item in orders)
            {
                if (skuids.Contains(item.SKUID))
                    exists = exists + 1;
            }
            if (exists > 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Here we will get price for non-promotional item
        /// </summary>
        /// <param name="SKUID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int GetPrice(string SKUID, int quantity)
        {
            return (OperationManager._SKUDetailsManager.SKUDetails[SKUID] * quantity);
        }

        /// <summary>
        /// This will get price for Discounted items
        /// </summary>
        /// <param name="SKUID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int GetDiscountedPrice(string SKUID, int quantity, PromotionDetails prom)
        {
            int finalprice = 0;
            int remainingQuantity = quantity;
            while (true)
            {
                finalprice = finalprice + (prom.DiscountPrice);
                remainingQuantity = remainingQuantity - prom.Count;
                if (remainingQuantity < prom.Count)
                {
                    finalprice = finalprice + (OperationManager._SKUDetailsManager.SKUDetails[SKUID] * remainingQuantity);
                    remainingQuantity = 0;
                }
                if (remainingQuantity <= 0)
                    break;
            }
            return finalprice;
        }
    }
}
