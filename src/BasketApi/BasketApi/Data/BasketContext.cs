using BasketApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Data
{
    public class BasketContext
        : IBasketContext
    {
        //Redis connect driver
        public object Redis { get; }

        public BasketContext()
        {
            //configura connection
        }
    }
}
