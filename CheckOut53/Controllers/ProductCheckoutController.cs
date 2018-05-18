using System.Collections.Generic;
using CheckOut53.Models;
using System.Web.Http;
using Newtonsoft.Json;

namespace CheckOut53.Controllers
{
  public  class ProductCheckoutController :ApiController
    {
        // GET: api/ProductCheckout
        public IList<Products> Get()
        {
            Products[] pro = Products.GetValue();
            return pro;
        }

        // POST: api/ProductCheckout
        public double Post([FromBody]string value)
        {
            IList<ProductCheckout> pc = JsonConvert.DeserializeObject<IList<ProductCheckout>>(value);
            return ProductCheckout.CalculateTotalPrice(pc);
        }


    }
}
