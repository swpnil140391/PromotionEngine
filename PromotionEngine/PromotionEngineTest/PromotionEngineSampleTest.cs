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
            OperationManager._PurchaseManager.CurrentOrderDetails.Clear();
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

        [TestMethod]
        public void TestMethod2()
        {
            OperationManager._PurchaseManager.CurrentOrderDetails.Clear();
            OrderDetails o1 = new OrderDetails();
            o1.SKUID = "A";
            o1.Quantity = 3;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "B";
            o1.Quantity = 5;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "C";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "D";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            Assert.AreEqual(OperationManager._BillingManager.PerformOperation(2), 280);
        }

        [TestMethod]
        public void TestMethod3()
        {
            OperationManager._PurchaseManager.CurrentOrderDetails.Clear();
            OrderDetails o1 = new OrderDetails();
            o1.SKUID = "A";
            o1.Quantity = 5;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "B";
            o1.Quantity = 5;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            o1 = new OrderDetails();
            o1.SKUID = "C";
            o1.Quantity = 1;
            OperationManager._PurchaseManager.CurrentOrderDetails.Add(o1);
            
            Assert.AreEqual(OperationManager._BillingManager.PerformOperation(2), 370);
        }


    }
}
