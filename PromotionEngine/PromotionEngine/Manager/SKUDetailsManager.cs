using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Manager
{
    /// <summary>
    /// this Class Will Manage the SKU's & their price
    /// </summary>
    class SKUDetailsManager
    {
        /// <summary>
        /// The given dictionary will manage the SKUDetails like SKU ID's & their price
        /// </summary>
        private Dictionary<string, int> SKUDetails = null;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SKUDetailsManager()
        {
            SKUDetails = new Dictionary<string, int>();
            SKUDetails.Add("A", 50);
            SKUDetails.Add("B", 30);
            SKUDetails.Add("C", 20);
            SKUDetails.Add("D", 15);
        }

        /// <summary>
        /// This Method will perform the Operations on SKU Details
        /// </summary>
        /// <param name="code"></param>
        public void PerformOperation(int code)
        {
            switch (code)
            {
                case 1:
                    #region Show SKU Details
                    foreach (var item in SKUDetails)
                    {
                        Console.WriteLine("SKU ID: " + item.Key + " Price: " + item.Value.ToString());
                    }
                    break; 
                    #endregion
                case 2:
                    #region Add SKU Details
                    {
                        Console.WriteLine("Please Specify the SKU ID :");
                        string ID = Console.ReadLine();
                        if (string.IsNullOrEmpty(ID))
                        {
                            Console.WriteLine("Empty SKUID is not allowed");
                            return;
                        }
                        if (IsSKUIDAlreadyExists(ID))
                        {
                            Console.WriteLine("SKUID already exists");
                            return;
                        }
                        int price = 0;
                        Console.WriteLine("Please enter the price : ");
                        if (!int.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid Price");
                            return;
                        }
                        SKUDetails.Add(ID, price);
                        Console.WriteLine("SKU Details added Successfully");
                        break;
                    } 
                    #endregion
                case 3:
                    #region Update SKU Details
                    {
                        Console.WriteLine("Please Specify the SKU ID :");
                        string ID = Console.ReadLine();
                        if (string.IsNullOrEmpty(ID))
                        {
                            Console.WriteLine("Empty SKUID is not allowed");
                            return;
                        }
                        if (!IsSKUIDAlreadyExists(ID))
                        {
                            Console.WriteLine("SKUID does not exists");
                            return;
                        }
                        int price = 0;
                        Console.WriteLine("Please enter the price : ");
                        if (!int.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Invalid Price");
                            return;
                        }
                        SKUDetails[ID] = price;
                        Console.WriteLine("SKU Details updated Successfully");
                        break;
                    }
                    #endregion
                default:
                    break;
            }
        }

        /// <summary>
        /// This Method will update the SKU Details
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="price"></param>
        public void UpdateSKUDetails(string ID, int price)
        {
            if (IsSKUIDAlreadyExists(ID))
            {
                SKUDetails[ID] = price;
            }
        }

        /// <summary>
        /// This Method will add SKU details
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="price"></param>
        public void AddSKUDetails(string ID , int price)
        {
            if(!IsSKUIDAlreadyExists(ID))
            {
                SKUDetails.Add(ID, price);
            }
        }

        /// <summary>
        /// This Method will validate whether SKU ID is already exists or not.
        /// </summary>
        /// <param name="SKUID"></param>
        /// <returns></returns>
        public bool IsSKUIDAlreadyExists(string SKUID)
        {
            if (string.IsNullOrEmpty(SKUID))
                throw new Exception("SKUID supplied cannot be blank");
            return SKUDetails.ContainsKey(SKUID);
        }
    }
}
