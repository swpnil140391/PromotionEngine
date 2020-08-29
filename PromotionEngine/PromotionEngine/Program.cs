using PromotionEngine.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    /// <summary>
    /// The Program Main Execution Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// The Main Execution Begins here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome To Promotion Engine");
                Console.WriteLine("#######################################");
                Console.WriteLine("1. Show the SKU Details");
                Console.WriteLine("2. Add the SKU Details");
                Console.WriteLine("3. Update the SKU Details");
                Console.WriteLine("4. Delete the SKU Details");
                Console.WriteLine("5. Show Active Promotions");
                Console.WriteLine("6. Add Count Promotions");
                Console.WriteLine("7. Go For Purchase");
                Console.WriteLine("8. View Final Bill");
                Console.WriteLine("#######################################");
                Console.WriteLine("Please Select your Desired Option");
                int code = 0;
                if (int.TryParse(Console.ReadLine(), out code))
                {
                    OperationManager.PerformOperation(code);
                }
                else
                {
                    Console.WriteLine("Invalid Operation Code, Please try again");
                }
                Console.WriteLine("Do you Want to Perform Once again Y/N");
                string val = Console.ReadLine();
                if (string.IsNullOrEmpty(val))
                    continue;
                else if (val.ToString().ToUpperInvariant() == "N")
                    break;
                else if (val.ToString().ToUpperInvariant() == "Y")
                    continue;
                else
                    Console.WriteLine("Invalid Choice! Please select again");
            }
        }
    }
}
