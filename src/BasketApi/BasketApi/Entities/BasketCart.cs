using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Entities
{
    public class BasketCart
    {
        public string UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();

        public BasketCart()
        {

        }

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        //calculate total price Items
        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(i => i.Quantity * i.Price);
            }
        }
    }
}
}
