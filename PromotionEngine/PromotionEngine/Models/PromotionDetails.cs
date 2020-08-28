using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    /// <summary>
    /// This Class will Manage the Promotion Details
    /// </summary>
    public class PromotionDetails
    {
        /// <summary>
        /// the sample Promotion Name
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// Whether the Promotion is Combined of SKUS or Count of Single
        /// </summary>
        public PromotionType Type { get; set; }

        /// <summary>
        /// SKUS Offered
        /// </summary>
        public List<string> SKUIDs { get; set; }

        /// <summary>
        /// Count if single SKUID is provided, otherwise default is '0'
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Discount Price for Promotion
        /// </summary>
        public int DiscountPrice { get; set; }
    }

    public enum PromotionType
    {
        Combined = 1,
        Count = 2
    }
}
