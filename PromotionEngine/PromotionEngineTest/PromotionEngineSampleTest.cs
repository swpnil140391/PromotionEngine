using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Manager;
using PromotionEngine.Models;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromotionEngineSampleTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            OrderDetails o1 = new OrderDetails();
            o1.SKUID = "A";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "B";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "C";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            Assert.AreEqual(OperationManager._BillingManager.PerformOperation(2), 100);
        }
    }
}
