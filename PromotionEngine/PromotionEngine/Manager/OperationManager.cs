using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Manager
{
    /// <summary>
    /// This Method will be responsible 
    /// </summary>
    public class OperationManager
    {
        public static SKUDetailsManager _SKUDetailsManager = new SKUDetailsManager();
        public static PromotionManager _PromotionManager = new PromotionManager();
        public static PurchaseManager _PurchaseManager = new PurchaseManager();
        public static BillingManager _BillingManager = new BillingManager();
        public static void PerformOperation(int code)
        {
            switch (code)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    _SKUDetailsManager.PerformOperation(code);
                    break;
                case 5:
                case 6:
                    _PromotionManager.PerformOperation(code);
                    break;
                case 7:
                    _PurchaseManager.PerformOperation(code);
                    break;
                case 8:
                    _BillingManager.PerformOperation(code);
                    break;
                default:
                    Console.WriteLine("Operation Code not found!");
                    break;
            }
        }
    }
}
