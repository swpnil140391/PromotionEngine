using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    /// <summary>
    /// This class will maange the Order Details
    /// </summary>
    class OrderDetails
    {
        /// <summary>
        /// SKU ID
        /// </summary>
        public string SKUID { get; set; }

        /// <summary>
        /// Quantity Purchased
        /// </summary>
        public int Quantity { get; set; }
    }
}
