using CheckOut53.Models;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;


namespace CheckOut53
{
   public class CheckOut
    {
        static void Main()
        {
            string baseAddress = "http://localhost:9001/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {

                string selected;
                int index;
                // Create HttpCient and make a request to api/ProductCheckOut 
                HttpClient client = new HttpClient();
                var response = client.GetAsync(baseAddress + "api/ProductCheckOut").Result;

                var outputresult = response.Content.ReadAsStringAsync().Result;
                IList<Products> items = JsonConvert.DeserializeObject<IList<Products>>(outputresult);

                StringBuilder sb = new StringBuilder();
                IList<ProductCheckout> productsCheckout = new List<ProductCheckout>();
                //Display data in tabular form
                sb.AppendLine("ID\t| Code\t| Description\t| Price\t| SpecialOffers");
                sb.AppendLine("---------------------------------------------------------");
                foreach (Products t in items)
                {

                    sb.Append(t.Id);
                    sb.Append("\t| ");
                    sb.Append(t.Sku);
                    sb.Append("\t| ");
                    sb.Append(t.Description);
                    sb.Append("\t| ");
                    sb.Append(t.Price);
                    sb.Append("\t| ");
                    sb.AppendLine(t.SpecialOffers);
                }
                Console.WriteLine(sb.ToString());
                do
                {
                    Console.WriteLine("Make a number selection for item you want to buy. 'S' to checkout");
                    selected = Console.ReadLine();
                    bool itemSelectionOk = Int32.TryParse(selected, out index);
                    if (itemSelectionOk & (index > 0 & index <= items.Count))
                    {
                        Console.WriteLine("Enter quantity: ");
                        var quantityIn = Console.ReadLine();
                        int quantity;
                        bool quantitySelectionOk = Int32.TryParse(quantityIn, out quantity);
                        if (quantitySelectionOk & quantity > 0)
                        {
                            ProductCheckout productCheckOut = new ProductCheckout();
                            productCheckOut.Id = index;

                            productCheckOut.Quantity = quantity;
                            productCheckOut.SpecialOffers = items.Single(s => s.Id == index).SpecialOffers;
                            productCheckOut.Price = items.Single(s => s.Id == index).Price;
                            productsCheckout.Add(productCheckOut);

                        }
                    }

                } while (selected != "S");
               // call the Api to calculate the product checkout price
                var responseresult = client.PostAsJsonAsync(baseAddress + "api/ProductCheckOut", JsonConvert.SerializeObject(productsCheckout)).Result;
                Decimal outputresult1 = Convert.ToDecimal(responseresult.Content.ReadAsStringAsync().Result);
                //display total price 
                Console.WriteLine("Your total: " + outputresult1.ToString("C", CultureInfo.CurrentCulture));
                Console.ReadLine();
            }
        }

    }
}

