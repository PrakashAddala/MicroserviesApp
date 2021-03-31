using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Entities;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        //private readonly IBasketContext _context;

        //public BasketRepository(IBasketContext context)
        //{
        //    _context = context;
        //}

         private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache
                                
                                    .RemoveAsync(userName);

                  
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket =await _redisCache
                          
                                    .GetStringAsync(userName);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            await _redisCache
                             .SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            //if (!updated)
            //{
            //    return null;
            //}
            return await GetBasket(basket.UserName);
        }
    }
}
