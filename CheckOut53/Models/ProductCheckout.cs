using System;
using System.Collections.Generic;

namespace CheckOut53.Models
{
    public class ProductCheckout
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string SpecialOffers { get; set; }
        public Double Price { get; set; }

        //Calculate the total price 
        public static double CalculateTotalPrice(IList<ProductCheckout> checkout)
        {
            Double price = 0;
            //iterate through checkout items
            foreach (var value in checkout)
            {
                if (value.SpecialOffers == null)
                    price += value.Price * value.Quantity;
                else
                {
                    var offervalue = value.SpecialOffers.Replace("for", ":").Split(':');
                    int offerquantity = Convert.ToInt16(offervalue[0]);
                    Decimal offerprice = Convert.ToDecimal(offervalue[1]);
                    //if have specialoffers
                    if (value.Quantity >= offerquantity)
                    {

                        Decimal result = Decimal.Divide(value.Quantity, offerquantity);
                        if (result % 1 > 0)
                        {
                            var intresult = (result.ToString().Split('.'))[0];
                            price += (value.Quantity - (Convert.ToDouble(intresult) * offerquantity)) * Convert.ToDouble(offerprice) + Convert.ToDouble(intresult) * Convert.ToDouble(value.Price);

                        }
                        else
                        {
                            price += Convert.ToDouble(result * offerprice);
                        }
                    }
                    //if no special offer
                    else
                        price += value.Price * value.Quantity;
                }
            }

            return price;
        }

    }
}
