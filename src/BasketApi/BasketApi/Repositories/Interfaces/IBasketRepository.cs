using BasketApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);
        Task<BasketCart> UpdateBaket(BasketCart basket);
        Task<bool> DeleteBasket(string userName);
        Task<bool> Checkout(BasketCheckout basketCheckout);
    }
}
