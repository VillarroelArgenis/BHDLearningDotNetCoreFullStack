using BasketApi.Data.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketApi.Data
{
    public class BasketContext
        : IBasketContext
    {
        private readonly ConnectionMultiplexer redisConnection;

        public BasketContext(ConnectionMultiplexer redisConnection)
        {
            this.redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
            Redis = redisConnection.GetDatabase();
        }


        //Redis connect driver
        public IDatabase Redis { get; }
        
        public BasketContext()
        {
            //configura connection
        }
    }
}
