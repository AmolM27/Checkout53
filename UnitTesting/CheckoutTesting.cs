using CheckOut53.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class CheckoutTesting
    {
        [TestMethod]
        public void GetProductDetail()
        {
         // Gets Product 
            Products[] pro = Products.GetValue();
            Assert.IsNotNull(pro);
        }

        [TestMethod]
        public void GetTotalPricewithSpecialOffers()
        {
            var pc = new ProductCheckout()
            {
                Id = 1,
                Quantity = 8,
                SpecialOffers = "3 for 1.30",
                Price = 0.5

            };
            IList<ProductCheckout> lpc = new List<ProductCheckout>{pc};
            ProductCheckout.CalculateTotalPrice(lpc);
            //3.6 is correct answer can change thsi to any other number to see test fail
            Assert.AreEqual("3.6", ProductCheckout.CalculateTotalPrice(lpc).ToString());
            
        }

        [TestMethod]
        public void GetTotalPricewithoutSpecialOffers()
        {
            var pc = new ProductCheckout()
            {
                Id = 3,
                Quantity = 4, 
                Price = 1.80

            };
            IList<ProductCheckout> lpc = new List<ProductCheckout> { pc };
            ProductCheckout.CalculateTotalPrice(lpc);
            //7.2 is correct answer can change thsi to any other number to see test fail
            Assert.AreEqual("7.2", ProductCheckout.CalculateTotalPrice(lpc).ToString());

        }
    }
}

