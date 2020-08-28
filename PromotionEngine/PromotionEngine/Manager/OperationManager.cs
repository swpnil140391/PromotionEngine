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
        private static SKUDetailsManager _SKUDetailsManager = new SKUDetailsManager();
        private static PromotionManager _PromotionManager = new PromotionManager(); 
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
                    _PromotionManager.PerformOperation(code);
                    break;
                default:
                    Console.WriteLine("Operation Code not found!");
                    break;
            }
        }
    }
}
