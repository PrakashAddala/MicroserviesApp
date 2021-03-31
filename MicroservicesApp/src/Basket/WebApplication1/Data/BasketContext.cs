using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;

namespace WebApplication1.Data
{
    public class BasketContext : IBasketContext
    {
        //private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDistributedCache _redisCache;

        public BasketContext(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }



        //public BasketContext(ConnectionMultiplexer redisConnection)
        //{
        //    _redisConnection = redisConnection;
        //    Redis = redisConnection.GetDatabase();
        //}

       // public IDatabase Redis { get; }
    }
}
