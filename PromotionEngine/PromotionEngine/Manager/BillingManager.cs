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
            Console.WriteLine("Final Bill : " + finalamount);
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
    }
}
