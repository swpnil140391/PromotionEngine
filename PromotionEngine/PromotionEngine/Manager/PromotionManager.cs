using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Manager
{
    /// <summary>
    /// This Class will deals with Adding/viewing/updating the Active Promotions
    /// </summary>
    class PromotionManager
    {
        /// <summary>
        /// Active Promotion Details
        /// </summary>
        private List<PromotionDetails> ActivePromotionDetails = new List<PromotionDetails>();

        /// <summary>
        /// Class Constructor
        /// </summary>
        public PromotionManager()
        {
            //Now will add default Promotion Details
            PromotionDetails details1 = new PromotionDetails();
            details1.PromotionName = "Promotion 1";
            details1.SKUIDs = new List<string>() { "A" };
            details1.Type = PromotionType.Count;
            details1.DiscountPrice = 130;
            details1.Count = 3;
            ActivePromotionDetails.Add(details1);

            PromotionDetails details2 = new PromotionDetails();
            details2.PromotionName = "Promotion 2";
            details2.SKUIDs = new List<string>() { "B" };
            details2.Type = PromotionType.Count;
            details2.DiscountPrice = 45;
            details2.Count = 2;
            ActivePromotionDetails.Add(details2);


            PromotionDetails details3 = new PromotionDetails();
            details3.PromotionName = "Promotion 3";
            details3.SKUIDs = new List<string>() { "C" , "D" };
            details3.Type = PromotionType.Combined;
            details3.DiscountPrice = 30;
            //details3.Count = 2;
            ActivePromotionDetails.Add(details3);
        }

        public void PerformOperation(int code)
        {
            switch (code)
            {
                case 5:
                    foreach (var item in ActivePromotionDetails)
                    {
                        Console.WriteLine("$$$$");
                        Console.WriteLine("Promotion Name : "+item.PromotionName);
                        Console.WriteLine("Promotion Discount Price : " + item.DiscountPrice);
                        switch (item.Type)
                        {
                            case PromotionType.Combined:
                                string finalstr = string.Empty;
                                foreach (var IDs in item.SKUIDs)
                                {
                                    finalstr = finalstr + IDs + ",";   
                                }
                                Console.WriteLine("Promotion Applicable for Combination of SKUs: " + finalstr.TrimEnd(','));
                                break;
                            case PromotionType.Count:
                                Console.WriteLine("Promotion Applicable for : " + item.Count + "'s of " + item.SKUIDs[0].ToString());
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("$$$$");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
