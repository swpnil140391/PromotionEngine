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
        }
    }
}
