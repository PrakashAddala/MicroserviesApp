using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> items { get; set; } = new List<BasketCartItem>();
        public BasketCart()
        {

        }
        public BasketCart(string userName)
        {
            UserName = userName;
        }


        //Total Price Calculation
        public decimal TotalPrice 
        {
            get
            {
                decimal totalprice = 0;
                foreach(var item in items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
                
        }



    }
}
