using AutoMapper;
using BasketApi.Data.Interfaces;
using BasketApi.Entities;
using BasketApi.Repositories.Interfaces;
using EventBusRabitMQ.Common;
using EventBusRabitMQ.Events;
using EventBusRabitMQ.Producer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Repositories
{
    public class BasketRepository
        : IBasketRepository
    {
        private readonly IBasketContext  context;
        private readonly IMapper mapper;
        private readonly EventBusRabbitMQProducer eventBus;

        public BasketRepository(IBasketContext context, IMapper mapper, EventBusRabbitMQProducer eventBus)
        {
            this.context = context;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await context.Redis
                .StringGetAsync(userName);

            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            var update = await context.Redis
                 .StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            if (!update)
                return null;

            return await GetBasket(basket.UserName);
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await context.Redis.KeyDeleteAsync(userName);
        }

        public async Task<bool> Checkout(BasketCheckout basketCheckout)
        {
            bool success = false;
            var basket = await GetBasket(basketCheckout.UserName);

            if (basket == null)
                return success;

            //send checkout event
            var eventMessage = mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;

            try
            {
                eventBus.PublishBasketCheckout(EventBusConstants.BasketCheckoutQueue, eventMessage);
                success = await DeleteBasket(basketCheckout.UserName);
            }
            catch (Exception)
            {

                throw;
            }
            return success;
        }
    }
}
