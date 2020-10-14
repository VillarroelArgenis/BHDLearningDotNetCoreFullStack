using BasketApi.Entities;
using BasketApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Repositories
{
    public class BasketRepository
        : IBasketRepository
    {
        private readonly IBasketRepository basketRepository;

        public BasketRepository(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        public Task<bool> Checkout(BasketCheckout basketCheckout)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketCart> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketCart> UpdateBaket(BasketCart basket)
        {
            throw new NotImplementedException();
        }
    }
}
