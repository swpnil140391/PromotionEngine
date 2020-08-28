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

        public static void PerformOperation(int code)
        {
            switch (code)
            {
                case 1:
                case 2:
                case 3:
                    _SKUDetailsManager.PerformOperation(code);
                    break;
                default:
                    break;
            }
        }
    }
}
