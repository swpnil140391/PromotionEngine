using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Manager
{
    /// <summary>
    /// This will Handle the purchase details for the same
    /// </summary>
    public class PurchaseManager
    {
        public List<OrderDetails> CurrentOrderDetails = new List<OrderDetails>();
        /// <summary>
        /// this method will perform the Purchase of SKUs
        /// </summary>
        /// <param name="code"></param>
        public void PerformOperation(int code)
        {
            Console.WriteLine("Please specify the SKU ID that you want to purchase : ");
            string ID = Console.ReadLine();
            if (string.IsNullOrEmpty(ID))
            {
                Console.WriteLine("Invalid SKU Details");
                return;
            }
            if (!OperationManager._SKUDetailsManager.IsSKUIDAlreadyExists(ID))
            {
                Console.WriteLine("SKU ID does not exists");
                return;
            }
            Console.WriteLine("Please enter the Quantity : ");
            int quantity = 0;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid Quantity Specified");
                return;
            }
            //now from here will write the Bussiness Logic for Appling the Promotion Code & Purchase details
            OrderDetails o1 = new OrderDetails();
            o1.SKUID = ID;
            o1.Quantity = quantity;
            if (!CurrentOrderDetails.Any(s => s.SKUID == ID))
                CurrentOrderDetails.Add(o1);
            else
            {
                CurrentOrderDetails.Where(s => s.SKUID == ID).First().Quantity = CurrentOrderDetails.Where(s => s.SKUID == ID).First().Quantity + quantity;
            }
            Console.WriteLine("Order added Successfully");
        }
    }
}
