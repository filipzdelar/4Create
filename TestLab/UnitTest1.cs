using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using _4Create.Entities.Models;

namespace TestLab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testProducts = ();
            var controller = new SimpleProductController(testProducts);

            var result = controller.GetAllProducts() as List<Product>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}
